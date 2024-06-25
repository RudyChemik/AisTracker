using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Models.History
{
    public class History
    {
        public int Id { get; set; }
        public int MMSI { get; set; }
        public int Course { get; set; }
        public int Speed { get; set; }
        public DateTime Time { get; set; }

        //refffs
        public ShipTrip shipTrip { get; set; }
        public int shipTripId { get; set; }
    }
}
