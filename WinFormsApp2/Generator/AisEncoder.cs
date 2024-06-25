using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp2.Models.Errors;
using WinFormsApp2.Models.Generator;

namespace WinFormsApp2.Generator
{
    public class AisEncoder
    {
        public (List<string> res, BasicErrorResponse error) EncodeAisData(List<Ship> randomShips)
        {
            List<string> encodedMessages = new List<string>();
            try
            {
                foreach (var ship in randomShips)
                {
                    var binary = BinaryBuilder(ship);
                    var encodedMessage = ConvertBinaryToAisMessage(binary);
                    encodedMessages.Add(encodedMessage);
                }
                return (encodedMessages, new BasicErrorResponse { Success = true });
            }
            catch (Exception e)
            {
                return (null, new BasicErrorResponse { Success = false, ErrorMessage = e.Message });
            }
        }

        private StringBuilder BinaryBuilder(Ship ship)
        {
            StringBuilder binaryMessage = new StringBuilder();

            binaryMessage.Append(Convert.ToString(3, 2).PadLeft(6, '0'));

            binaryMessage.Append("00");

            binaryMessage.Append(Convert.ToString(ship.MMSI, 2).PadLeft(30, '0'));

            binaryMessage.Append(Convert.ToString(ship.Status, 2).PadLeft(4, '0'));

            binaryMessage.Append(Convert.ToString(ship.RateOfTurn, 2).PadLeft(8, '0'));

            binaryMessage.Append(Convert.ToString((int)(ship.SpeedOverGround * 10), 2).PadLeft(10, '0'));

            binaryMessage.Append("1");

            int longitude = (int)(ship.Longitude * 600000);
            binaryMessage.Append(Convert.ToString(longitude < 0 ? (longitude & 0x0FFFFFFF) : longitude, 2).PadLeft(28, '0'));

            int latitude = (int)(ship.Latitude * 600000);
            binaryMessage.Append(Convert.ToString(latitude < 0 ? (latitude & 0x07FFFFFF) : latitude, 2).PadLeft(27, '0'));

            binaryMessage.Append(Convert.ToString((int)(ship.CourseOverGround * 10), 2).PadLeft(12, '0'));

            binaryMessage.Append(Convert.ToString(ship.Heading, 2).PadLeft(9, '0'));

            binaryMessage.Append("111111");

            binaryMessage.Append("00");

            binaryMessage.Append("000");

            binaryMessage.Append("0");

            binaryMessage.Append(new string('0', 19));

            return binaryMessage;
        }

        private string ConvertBinaryToAisMessage(StringBuilder binary)
        {
            string encodedMessage = Encode6BitAscii(binary.ToString());
            string messageWithoutChecksum = $"!AIVDM,1,1,,B,{encodedMessage},0*";
            string checksum = CalculateChecksum(messageWithoutChecksum);
            return $"{messageWithoutChecksum}{checksum}";
        }

        private string Encode6BitAscii(string binary)
        {
            StringBuilder encoded = new StringBuilder();

            for (int i = 0; i < binary.Length; i += 6)
            {
                string sixBitChunk = binary.Substring(i, Math.Min(6, binary.Length - i));
                int value = Convert.ToInt32(sixBitChunk, 2);

                if (value < 40)
                    value += 48;
                else
                    value += 56;

                encoded.Append((char)value);
            }

            return encoded.ToString();
        }

        private string CalculateChecksum(string message)
        {
            int checksum = 0;
            foreach (char c in message)
            {
                checksum ^= c;
            }
            return checksum.ToString("X2");
        }
    }
}
