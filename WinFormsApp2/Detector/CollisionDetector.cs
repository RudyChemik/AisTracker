using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsApp2.Decoder;
using WinFormsApp2.Models.AisCommunicates;
using WinFormsApp2.Models.Generator;

namespace WinFormsApp2.Detector
{
    public class CollisionDetector
    {
        private const double CollisionDistanceThreshold = 0.002; // 222 m.
        private AisDecoder decoder = new AisDecoder();

        public CollisionVMO? PredictCollision(List<string> aisMessages, int predictionDurationSeconds, int timeStepSeconds)
        {
            var (ships, ownShip) = GetDataFromAIS(aisMessages);

            for (int t = 0; t <= predictionDurationSeconds; t += timeStepSeconds)
            {
                PointLatLng ownShipFuturePosition = PredictFuturePosition(ownShip, t);

                foreach (var otherShip in ships)
                {
                    PointLatLng otherShipFuturePosition = PredictFuturePosition(otherShip, t);
                    double distance = GetDistance(ownShipFuturePosition, otherShipFuturePosition);

                    if (distance < CollisionDistanceThreshold)
                    {
                        return new CollisionVMO
                        {
                            TimeToCollision = DateTime.Now.AddSeconds(t),
                            CollisionShipMMSI = otherShip.MMSI,
                            CollisionPointLat = (ownShipFuturePosition.Lat + otherShipFuturePosition.Lat) / 2,
                            CollisionPointLong = (ownShipFuturePosition.Lng + otherShipFuturePosition.Lng) / 2
                        };
                    }
                }
            }

            return null;
        }

        private (List<Ship> ships, Ship ownShip) GetDataFromAIS(List<string> aisMessages)
        {
            Ship ownShip = null;
            List<Ship> shipList = new List<Ship>();

            foreach (var ais in aisMessages)
            {
                var decoded = decoder.DecodeAisMessage(ais);
                if (decoded != null)
                {
                    if (decoded.mmsi == 200000000)
                    {
                        ownShip = new Ship
                        {
                            MMSI = decoded.mmsi,
                            Longitude = decoded.longg,
                            Latitude = decoded.lat,
                            CourseOverGround = decoded.cog,
                            SpeedOverGround = decoded.sog,
                            Status = decoded.stat,
                            RateOfTurn = 0,
                            Heading = decoded.head
                        };
                    }
                    else
                    {
                        Ship ship = new Ship
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
                        shipList.Add(ship);
                    }
                }
            }

            return (shipList, ownShip);
        }

        private PointLatLng PredictFuturePosition(Ship ship, int timeInSeconds)
        {
            double speedMps = ship.SpeedOverGround * 0.514444;
            double distance = speedMps * timeInSeconds;

            double cogRadians = ship.CourseOverGround * Math.PI / 180.0;

            double deltaLatitude = distance * Math.Cos(cogRadians) / 111320.0;
            double deltaLongitude = distance * Math.Sin(cogRadians) / (111320.0 * Math.Cos(ship.Latitude * Math.PI / 180.0));

            double futureLatitude = ship.Latitude + deltaLatitude;
            double futureLongitude = ship.Longitude + deltaLongitude;

            return new PointLatLng(futureLatitude, futureLongitude);
        }

        private double GetDistance(PointLatLng point1, PointLatLng point2)
        {
            double dLat = point2.Lat - point1.Lat;
            double dLon = point2.Lng - point1.Lng;

            return Math.Sqrt(dLat * dLat + dLon * dLon);
        }
    }

    public class CollisionVMO
    {
        public DateTime TimeToCollision { get; set; }
        public int CollisionShipMMSI { get; set; }
        public double CollisionPointLong { get; set; }
        public double CollisionPointLat { get; set; }
    }
}
