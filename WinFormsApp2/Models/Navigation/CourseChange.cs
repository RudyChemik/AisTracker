using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Models.Navigation
{
    public class CourseChange
    {
        public int MMSI { get; set; } = 200000000;
        public int Course { get; set; }
        public int Speed { get; set; }
        public DateTime timeChanged { get; set; }
    }
}
