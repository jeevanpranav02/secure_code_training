using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PublicKeyCryptography.Services
{
    public class CryptoGraphicService
    {
        private const string PrivateKeyPath = "keys/private_key.xml";
        private const string PublicKeyPath = "keys/public_key.xml";

        public void GenerateKeys()
        {
            Directory.CreateDirectory("keys");
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                File.WriteAllText(PrivateKeyPath, rsa.ToXmlString(true));
                File.WriteAllText(PublicKeyPath, rsa.ToXmlString(false));
            }
        }

        public byte[] EncryptData(string data)
        {
            if (!File.Exists(PublicKeyPath))
                throw new FileNotFoundException("Public key not found. Generate keys first.");
            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(File.ReadAllText(PublicKeyPath));
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                return rsa.Encrypt(dataBytes, false);
            }
        }

        public string DecryptData(byte[] encryptedData)
        {
            if (!File.Exists(PrivateKeyPath))
                throw new FileNotFoundException("Private key not found. Generate keys first.");
            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(File.ReadAllText(PrivateKeyPath));
                byte[] decryptedBytes = rsa.Decrypt(encryptedData, false);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}

