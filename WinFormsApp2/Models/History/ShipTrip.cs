using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Models.History
{
    public class ShipTrip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public double StartingLat { get; set; }
        public double StartingLong { get; set; }
        public DateTime StartingTime { get; set; }
        public List<History>? histories { get; set; }
    }
}
