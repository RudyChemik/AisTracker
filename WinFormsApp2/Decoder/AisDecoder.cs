using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.Models.AisCommunicates;
using System.Windows.Forms;

namespace WinFormsApp2.Decoder
{
    public class AisDecoder
    {
        public AisDecoder() { }

        public AisDecoded DecodeAisMessage(string nmeaSentence)
        {
            if (!nmeaSentence.StartsWith("!AIVD"))
            {
                MessageBox.Show("ERROR");
                return null;
            }

            var parts = nmeaSentence.Split(',');

            if (parts.Length < 6)
            {
                MessageBox.Show("ERROR");
                return null;
            }

            string encodedMsg = parts[5];

            string msg = Ais(encodedMsg);

            int mmsi = UserIdDecode(msg);
            double lat = LatDecode(msg);
            double longg = LongDecode(msg);
            int status = StatDecode(msg);
            double cog = CogDecode(msg);
            double sog = SogDecode(msg);
            double rot = RotDecode(msg);
            int head = HeadDecode(msg);

            AisDecoded msgDecoded = new AisDecoded()
            {
                mmsi = mmsi,
                lat = lat,
                longg = longg,
                sog = sog,
                cog = cog,
                rot = rot,
                head = head,
                stat = status,
            };

            return msgDecoded;
        }

        private string Ais(string encoded)
        {
            StringBuilder binary = new StringBuilder();
            foreach (char c in encoded)
            {
                int val = c - 48;
                if (val > 40) val -= 8;
                binary.Append(Convert.ToString(val, 2).PadLeft(6, '0'));
            }
            return binary.ToString();
        }

        private int UserIdDecode(string binaryMessage)
        {
            return Convert.ToInt32(binaryMessage.Substring(8, 30), 2);
        }

        private double LatDecode(string binaryMessage)
        {
            int rawLat = Convert.ToInt32(binaryMessage.Substring(89, 27), 2);
            if (rawLat >= 0x4000000)
                rawLat -= 0x8000000;
            return rawLat / 600000.0;
        }

        private double LongDecode(string binaryMessage)
        {
            int rawLon = Convert.ToInt32(binaryMessage.Substring(61, 28), 2);
            if (rawLon >= 0x8000000)
                rawLon -= 0x10000000;
            return rawLon / 600000.0;
        }

        private int StatDecode(string binaryMessage)
        {
            return Convert.ToInt32(binaryMessage.Substring(38, 4), 2);
        }

        private double CogDecode(string binaryMessage)
        {
            return Convert.ToInt32(binaryMessage.Substring(116, 12), 2) * 0.1;
        }

        private double SogDecode(string binaryMessage)
        {
            return Convert.ToInt32(binaryMessage.Substring(50, 10), 2) * 0.1;
        }

        private double RotDecode(string binaryMessage)
        {
            int rawRot = Convert.ToInt32(binaryMessage.Substring(42, 8), 2);
            double rot = rawRot / 4.733;
            rot *= rot * (rawRot < 0 ? -1 : 1);
            return rot;
        }

        private int HeadDecode(string binaryMessage)
        {
            return Convert.ToInt32(binaryMessage.Substring(128, 9), 2);
        }
    }
}
