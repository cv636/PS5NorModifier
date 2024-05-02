using System.Text.RegularExpressions;
using System.Text;

namespace PS5NORModifier.Models {
    public class PS5_Non_Slim : IPlayStation {
        long _offsetOne = 0x1c7010;
        long _offsetTwo = 0x1c7030;
        long _WiFiMacOffset = 0x1C73C0;
        long _LANMacOffset = 0x1C4020;
        long _serialOffset = 0x1c7210;
        long _variantOffset = 0x1c7226;
        long _moboSerialOffset = 0x1C7200;
        string? _WiFiMacValue = null, _LANMacValue = null, _offsetOneValue = null, _offsetTwoValue = null, _serialValue = null
            , _variantHexValue = null, _variantStrValue, _moboSerialValue = null, _modelInfo = null;

        public string Name => "PS5 (Non-Slim)";

        public string GetBoardVariant() => _variantStrValue ?? "Unknown";

        public string GetLanMac() => _LANMacValue ?? "Unknown";

        public string GetModel() => _modelInfo ?? "Unknown";

        public string GetMotherboardSerialNumber() => string.IsNullOrWhiteSpace(_moboSerialValue) ? "Unknown" : Helper.HexStringToString(_moboSerialValue);

        public byte[] WriteNORAsync(byte[] newFileBytes, string? newBoardModel, string? newSN, string? newVariant) {
            List<string> errors = new();

            #region Set the new model info
            if (_modelInfo == "Disc Edition") {
                try {

                    if (newBoardModel == "Digital Edition") {

                        byte[] find = Helper.ConvertHexStringToByteArray(Regex.Replace("22020101", "0x|[ ,]", string.Empty).Normalize().Trim());
                        byte[] replace = Helper.ConvertHexStringToByteArray(Regex.Replace("22030101", "0x|[ ,]", string.Empty).Normalize().Trim());
                        if (find.Length != replace.Length) {
                            errors.Add("The length of the old hex value does not match the length of the new hex value!");
                        }
                        ReplaceBytes(newFileBytes, find, replace);
                    }

                } catch {
                    errors.Add("An error occurred while saving your BIOS file");

                }
            } else {
                if (_modelInfo == "Digital Edition") {
                    try {

                        if (newBoardModel == "Disc Edition") {

                            byte[] find = Helper.ConvertHexStringToByteArray(Regex.Replace("22030101", "0x|[ ,]", string.Empty).Normalize().Trim());
                            byte[] replace = Helper.ConvertHexStringToByteArray(Regex.Replace("22020101", "0x|[ ,]", string.Empty).Normalize().Trim());
                            if (find.Length != replace.Length) {
                                errors.Add("The length of the old hex value does not match the length of the new hex value!");

                            }
                            ReplaceBytes(newFileBytes, find, replace);
                        }

                    } catch {
                        errors.Add("An error occurred while saving your BIOS file");

                    }
                }
            }
            #endregion

            #region Set the new board variant
            if (!string.IsNullOrWhiteSpace(newVariant)) {
                try {
                    if (!string.IsNullOrWhiteSpace(_variantHexValue)) {

                        byte[] newVariantSelection = Encoding.UTF8.GetBytes(newVariant);
                        string newVariantHex = Convert.ToHexString(newVariantSelection);

                        byte[] find = Helper.ConvertHexStringToByteArray(Regex.Replace(_variantHexValue, "0x|[ ,]", string.Empty).Normalize().Trim());
                        byte[] replace = Helper.ConvertHexStringToByteArray(Regex.Replace(newVariantHex, "0x|[ ,]", string.Empty).Normalize().Trim());

                        ReplaceBytes(newFileBytes, find, replace);
                    } else {
                        errors.Add("Missing old variant value");
                    }
                } catch (ArgumentException ex) {
                    errors.Add(ex.Message.ToString());
                }
            }

            #endregion

            #region Change Serial Number
            if (!string.IsNullOrWhiteSpace(newSN)) {
                try {
                    if (!string.IsNullOrWhiteSpace(_serialValue)) {

                        byte[] newSerial = Encoding.UTF8.GetBytes(newSN);
                        string newSerialHex = Convert.ToHexString(newSerial);

                        byte[] find = Helper.ConvertHexStringToByteArray(Regex.Replace(_serialValue, "0x|[ ,]", string.Empty).Normalize().Trim());
                        byte[] replace = Helper.ConvertHexStringToByteArray(Regex.Replace(newSerialHex, "0x|[ ,]", string.Empty).Normalize().Trim());

                        ReplaceBytes(newFileBytes, find, replace);
                    } else {
                        errors.Add("Missing serial number to replace");
                    }

                } catch (ArgumentException ex) {
                    errors.Add(ex.Message.ToString());

                }
            }

            #endregion
            if (errors.Any())
                throw new Exception($"Errors when trying to write new file: {string.Join(Environment.NewLine, errors)}");
            return newFileBytes;
        }

        private static void ReplaceBytes(byte[] newFileBytes, byte[] find, byte[] replace) {
            foreach (int index in PatternAt(newFileBytes, find)) {
                for (int i = index, replaceIndex = 0; i < newFileBytes.Length && replaceIndex < replace.Length; i++, replaceIndex++) {
                    newFileBytes[i] = replace[replaceIndex];
                }
            }
        }

        public string GetPSSerialNumber() => string.IsNullOrWhiteSpace(_serialValue) ? "Unknown" : Helper.HexStringToString(_serialValue);

        public string GetWifiMac() => _WiFiMacValue ?? "Unknown";

        public async Task ReadNORAsync(string filePath) {
            MemoryStream ms = new();
            using (FileStream fs = new(filePath, FileMode.Open)) {
                await fs.CopyToAsync(ms);
            };
            BinaryReader reader = new(ms);


            try {
                //BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
                //Set the position of the reader
                //reader.BaseStream.Position = _offsetOne;
                reader.BaseStream.Seek(_offsetOne, SeekOrigin.Begin);
                //Read the offset
                _offsetOneValue = BitConverter.ToString(reader.ReadBytes(12)).Replace("-", null);
                //reader.Close();
                if (_offsetOneValue?.Contains("22020101") ?? false) {
                    _modelInfo = "Disc Edition";
                }
            } catch {
                // Obviously this value is invalid, so null the value and move on
                _offsetOneValue = null;
            }
            if (_modelInfo is null) {
                try {
                    reader.BaseStream.Seek(_offsetTwo, SeekOrigin.Begin);
                    //Read the offset
                    _offsetTwoValue = BitConverter.ToString(reader.ReadBytes(12)).Replace("-", null);
                    //reader.Close();
                    if (_offsetTwoValue?.Contains("22030101") ?? false) {
                        _modelInfo = "Digital Edition";
                    }
                } catch {
                    // Obviously this value is invalid, so null the value and move on
                    _offsetTwoValue = null;
                }
            }

            #region Extract Motherboard Serial Number
            try {
                //BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
                //Set the position of the reader
                //reader.BaseStream.Position = _moboSerialOffset;
                reader.BaseStream.Seek(_moboSerialOffset, SeekOrigin.Begin);
                //Read the offset
                _moboSerialValue = BitConverter.ToString(reader.ReadBytes(16)).Replace("-", null);
                //reader.Close();
            } catch {
                // Obviously this value is invalid, so null the value and move on
                _moboSerialValue = null;
            }
            #endregion

            #region Extract Board Serial Number

            try {
                //BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
                //Set the position of the reader
                //reader.BaseStream.Position = _serialOffset;
                reader.BaseStream.Seek(_serialOffset, SeekOrigin.Begin);
                //Read the offset
                _serialValue = BitConverter.ToString(reader.ReadBytes(17)).Replace("-", null);
                //reader.Close();
            } catch {
                // Obviously this value is invalid, so null the value and move on
                _serialValue = null;
            }





            #endregion

            #region Extract WiFi Mac Address

            try {
                //BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
                //Set the position of the reader
                //reader.BaseStream.Position = _WiFiMacOffset;
                reader.BaseStream.Seek(_WiFiMacOffset, SeekOrigin.Begin);
                //Read the offset
                _WiFiMacValue = BitConverter.ToString(reader.ReadBytes(6));
                //reader.Close();
            } catch {
                // Obviously this value is invalid, so null the value and move on
                _WiFiMacValue = null;
            }

            #endregion

            #region Extract LAN Mac Address

            try {
                //BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
                //Set the position of the reader
                //reader.BaseStream.Position = _LANMacOffset;
                reader.BaseStream.Seek(_LANMacOffset, SeekOrigin.Begin);
                //Read the offset
                _LANMacValue = BitConverter.ToString(reader.ReadBytes(6));
                //reader.Close();
            } catch {
                // Obviously this value is invalid, so null the value and move on
                _LANMacValue = null;
            }

            #endregion

            #region Extract Board Variant

            try {
                //BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
                //Set the position of the reader
                //reader.BaseStream.Position = _variantOffset;
                reader.BaseStream.Seek(_variantOffset, SeekOrigin.Begin);
                //Read the offset
                _variantHexValue = BitConverter.ToString(reader.ReadBytes(19)).Replace("-", null).Replace("FF", null);
                _variantStrValue = Helper.HexStringToString(_variantHexValue);
                //reader.Close();
            } catch {
                // Obviously this value is invalid, so null the value and move on
                _variantHexValue = null;
            }




            if (_variantStrValue is not null) {
                _variantStrValue += _variantStrValue switch {
                    _ when _variantStrValue.EndsWith("00A") || _variantStrValue.EndsWith("00B") => " - Japan",
                    _ when _variantStrValue.EndsWith("01A") || _variantStrValue.EndsWith("01B") ||
                           _variantStrValue.EndsWith("15A") || _variantStrValue.EndsWith("15B") => " - US, Canada, (North America)",
                    _ when _variantStrValue.EndsWith("02A") || _variantStrValue.EndsWith("02B") => " - Australia / New Zealand, (Oceania)",
                    _ when _variantStrValue.EndsWith("03A") || _variantStrValue.EndsWith("03B") => " - United Kingdom / Ireland",
                    _ when _variantStrValue.EndsWith("04A") || _variantStrValue.EndsWith("04B") => " - Europe / Middle East / Africa",
                    _ when _variantStrValue.EndsWith("05A") || _variantStrValue.EndsWith("05B") => " - South Korea",
                    _ when _variantStrValue.EndsWith("06A") || _variantStrValue.EndsWith("06B") => " - Southeast Asia / Hong Kong",
                    _ when _variantStrValue.EndsWith("07A") || _variantStrValue.EndsWith("07B") => " - Taiwan",
                    _ when _variantStrValue.EndsWith("08A") || _variantStrValue.EndsWith("08B") => " - Russia, Ukraine, India, Central Asia",
                    _ when _variantStrValue.EndsWith("09A") || _variantStrValue.EndsWith("09B") => " - Mainland China",
                    _ when _variantStrValue.EndsWith("11A") || _variantStrValue.EndsWith("11B") ||
                           _variantStrValue.EndsWith("14A") || _variantStrValue.EndsWith("14B")
                        => " - Mexico, Central America, South America",
                    _ when _variantStrValue.EndsWith("16A") || _variantStrValue.EndsWith("16B") => " - Europe / Middle East / Africa",
                    _ when _variantStrValue.EndsWith("18A") || _variantStrValue.EndsWith("18B") => " - Singapore, Korea, Asia",
                    _ => " - Unknown Region"
                };
            }
            if (reader is not null) {
                reader.Close();
                reader.Dispose();
            }
            #endregion
        }

        /// <summary>
        /// With thanks to  @jjxtra on Github. The code has already been created and there's no need to reinvent the wheel is there?
        /// </summary>
        #region Hex Code

        private static IEnumerable<int> PatternAt(byte[] source, byte[] pattern) {
            for (int i = 0; i < source.Length; i++) {
                if (source.Skip(i).Take(pattern.Length).SequenceEqual(pattern)) {
                    yield return i;
                }
            }
        }
        #endregion
    }
}
