using GMap.NET;
using System.Collections.Generic;
using System.Linq;
using WinFormsApp2.Decoder;
using WinFormsApp2.Models.AisCommunicates;
using WinFormsApp2.Models.Generator;
using WinFormsApp2.Models.Navigation;

namespace WinFormsApp2.Generator
{
    public class SimulateMovement
    {
        private List<string> aisMessages;
        private AisDecoder aisDecoder;
        private AisEncoder aisEncoder;
        private int timeIntervalInSeconds;
        private Random random;

        private List<CourseChange> courseChanges;

        public SimulateMovement(List<string> initialAisMessages, AisDecoder decoder, AisEncoder encoder, List<CourseChange> changes, int timeIntervalInSeconds = 5)
        {
            aisMessages = initialAisMessages;
            aisDecoder = decoder;
            aisEncoder = encoder;
            this.timeIntervalInSeconds = timeIntervalInSeconds;
            random = new Random();

            courseChanges = changes;
        }

        public (List<string> res, bool changed) Simulate()
        {
            bool changed = false;
            List<AisDecoded> decodedShips = aisMessages.Select(aisDecoder.DecodeAisMessage).ToList();
            foreach (var ship in decodedShips)
            {
                var changedCourse = UpdateShipPosition(ship, timeIntervalInSeconds, courseChanges);
                if (changedCourse) { changed = true; }
            }

            List<Ship> ships = decodedShips.Select(ConvertToShip).ToList();
            var encodedMessages = aisEncoder.EncodeAisData(ships);

            if (!encodedMessages.error.Success || encodedMessages.res == null)
            {
                return (null, changed);
            }

            aisMessages = encodedMessages.res;

            return (aisMessages, changed);
        }

        private bool UpdateShipPosition(AisDecoded ship, double timeIntervalInSeconds, List<CourseChange> changes)
        {
            bool changedCourse = false;

            double speedMps = ship.sog * 0.514444;

            double distance = speedMps * timeIntervalInSeconds;

            double cogRadians = ship.cog * Math.PI / 180.0;

            double deltaLatitude = distance * Math.Cos(cogRadians) / 111320.0; 
            double deltaLongitude = distance * Math.Sin(cogRadians) / (111320.0 * Math.Cos(ship.lat * Math.PI / 180.0));

            ship.lat += deltaLatitude;
            ship.longg += deltaLongitude;

            if (courseChanges != null && courseChanges.Count > 0)
            {
                var courseChange = courseChanges.FirstOrDefault(c => c.MMSI == ship.mmsi);
                if (courseChange != null)
                {
                    ship.cog = courseChange.Course;
                    ship.sog = courseChange.Speed;

                    changedCourse = true;
                }
            }

            if (random.NextDouble() <= 0.05)
            {
                ship.cog += random.Next(-30, 30);
                if (ship.cog < 0)
                {
                    ship.cog += 360;
                }
                else if (ship.cog >= 360)
                {
                    ship.cog -= 360;
                }
            }
            return changedCourse;
        }

        public List<PointLatLng> PredictFuturePositions(AisDecoded ship, int predictionTimeInSeconds)
        {
            List<PointLatLng> futurePositions = new List<PointLatLng>();

            double currentLat = ship.lat;
            double currentLong = ship.longg;
            double speedMps = ship.sog * 0.514444;
            double cogRadians = ship.cog * Math.PI / 180.0;

            for (int t = 0; t < predictionTimeInSeconds; t += timeIntervalInSeconds)
            {
                double distance = speedMps * timeIntervalInSeconds;
                double deltaLatitude = distance * Math.Cos(cogRadians) / 111320.0;
                double deltaLongitude = distance * Math.Sin(cogRadians) / (111320.0 * Math.Cos(currentLat * Math.PI / 180.0));

                currentLat += deltaLatitude;
                currentLong += deltaLongitude;

                futurePositions.Add(new PointLatLng(currentLat, currentLong));
            }

            return futurePositions;
        }

        private Ship ConvertToShip(AisDecoded decoded)
        {
            return new Ship
            {
                MMSI = decoded.mmsi,
                Latitude = decoded.lat,
                Longitude = decoded.longg,
                Status = decoded.stat,
                RateOfTurn = 0,
                SpeedOverGround = decoded.sog,
                CourseOverGround = decoded.cog,
                Heading = decoded.head
            };
        }
    }
}
