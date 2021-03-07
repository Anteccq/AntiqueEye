using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AntiqueEye.Models.Cryptography
{
    public class EyeCrypto : IEyeCrypto
    {
        private const int saltSize = 16;
        private const int keySize = 16;

        public byte[] DecryptAsync(string password, Message message)
        {

        }

        public Message EncryptAsync(string password, byte[] rawData)
        {
            using var deriveBytes = new Rfc2898DeriveBytes(password, saltSize);
            var salt = deriveBytes.Salt;
            using var encAlg = Aes.Create();
            encAlg.Key = deriveBytes.GetBytes(keySize);
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encAlg.CreateEncryptor(), CryptoStreamMode.Write);
            using var binaryWriter = new BinaryWriter(cs);
            binaryWriter.Write(rawData);
            var message = new Message
            {
                EncryptedData = ms.ToArray(),
                Iv = encAlg.IV
            };
            return message;
        }
    }
}
