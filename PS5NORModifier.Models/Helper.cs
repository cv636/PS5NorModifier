using System.Globalization;
using System.Text;

namespace PS5NORModifier.Models {
    public static class Helper {
        public static string HexStringToString(string hexString) {
            if (hexString == null || (hexString.Length & 1) == 1) {
                throw new ArgumentException();
            }
            var sb = new StringBuilder();
            for (var i = 0; i < hexString.Length; i += 2) {
                var hexChar = hexString.Substring(i, 2);
                sb.Append((char)Convert.ToByte(hexChar, 16));
            }
            return sb.ToString();
        }
        public static byte[] ConvertHexStringToByteArray(string hexString) {
            if (hexString.Length % 2 != 0) {
                throw new ArgumentException($"The binary key cannot have an odd number of digits: '{hexString}'");
            }
            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++) {
                string byteValue = hexString[(index * 2)..2];
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            return data;
        }
    }
}
