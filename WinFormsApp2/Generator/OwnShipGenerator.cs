using System;
using WinFormsApp2.Models.Errors;
using WinFormsApp2.Models.Generator;

namespace WinFormsApp2.Generator
{
    public class OwnShipGenerator
    {
        private static Random random = new Random();

        public OwnShipGenerator() { }

        public (Ship? res, BasicErrorResponse error) GenerateOwnShip(int MMSI)
        {

            if(MMSI < 200000000 || MMSI > 799999999)
            {
                return (null, new BasicErrorResponse() { Success = false, ErrorMessage = "ID NOT IN THE AIS RANGE" });
            }

            try
            {
                Ship ship = new Ship()
                {
                    MMSI = MMSI,
                    Latitude = 53.936159837443874,
                    Longitude = 14.286524602076607,
                    RateOfTurn = 0,
                    Status = random.Next(0, 15),
                    SpeedOverGround = 10.0,
                    CourseOverGround = random.Next(0, 360),
                    Heading = random.Next(0, 360)
                };

                return (ship, new BasicErrorResponse() { Success = true });
            }
            catch (Exception e)
            {
                return (null, new BasicErrorResponse() { Success = false, ErrorMessage = e.Message });
            }
        }
    }
}
