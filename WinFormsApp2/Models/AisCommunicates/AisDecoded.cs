using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Models.AisCommunicates
{
    public class AisDecoded
    {
        public int mmsi { get; set; }
        public double lat { get; set; }
        public double longg { get; set; }
        public int stat { get; set; }
        public double cog { get; set; }
        public double sog { get; set; }
        public double rot { get; set; }
        public int head { get; set; }
    }

}
