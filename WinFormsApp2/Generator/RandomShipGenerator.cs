using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.Models.Errors;
using WinFormsApp2.Models.Generator;

namespace WinFormsApp2.Generator
{
    public class RandomShipGenerator
    {
        public RandomShipGenerator() { }
        private Random random = new Random();
        public (List<Ship>? res, BasicErrorResponse error) GenerateRandomShips(int count)
        {
            List<Ship> shipsRes = new List<Ship>();
            try
            {
                double minLat = 53.980250418510664, maxLat = 55.0132858668513;
                double minLon = 14.183380584418712, maxLon = 15.323986018022435;

                for (int i = 0; i < count; i++)
                {
                    Ship ship = new Ship()
                    {
                        MMSI = random.Next(200000000, 799999999),
                        Latitude = random.NextDouble() * (maxLat - minLat) + minLat,
                        Longitude = random.NextDouble() * (maxLon - minLon) + minLon,
                        RateOfTurn = 0,
                        Status = random.Next(0, 15),
                        SpeedOverGround = random.Next(5, 15),
                        CourseOverGround = random.Next(0, 360),
                        Heading = random.Next(0, 360)
                    };
                    shipsRes.Add(ship);
                }
                return (shipsRes, new BasicErrorResponse() { Success = true });
            }
            catch (Exception e)
            {
                return (shipsRes, new BasicErrorResponse() { Success = false, ErrorMessage = e.Message });
            }
        }




    }
}
