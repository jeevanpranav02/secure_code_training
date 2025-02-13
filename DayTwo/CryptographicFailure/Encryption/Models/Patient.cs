namespace Encryption.Models
{
    class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }
        public string HistoryOfIllness { get; set; }
        public byte[] EncryptedData { get; set; }
    }
}
