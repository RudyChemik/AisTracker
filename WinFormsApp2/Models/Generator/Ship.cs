using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Models.Generator
{
    public class Ship
    {
        public int MMSI { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Status { get; set; }
        public int RateOfTurn { get; set; }
        public double SpeedOverGround { get; set; } //knots
        public double CourseOverGround { get; set; } //degrees
        public int Heading { get; set; }
    }
}
