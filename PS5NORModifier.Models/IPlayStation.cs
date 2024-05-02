namespace PS5NORModifier.Models {
    public interface IPlayStation {
        public string Name { get; }
        public string GetWifiMac();
        public string GetLanMac();
        public string GetModel();
        public string GetBoardVariant();
        public string GetPSSerialNumber();
        public string GetMotherboardSerialNumber();
        public Task ReadNORAsync(string filePath);
        byte[] WriteNORAsync(byte[] newFileBytes, string? newBoardModel, string? newSN, string? newVariant);
    }
}
