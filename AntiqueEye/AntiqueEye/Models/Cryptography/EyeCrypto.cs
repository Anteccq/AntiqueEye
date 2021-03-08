using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AntiqueEye.Models.Cryptography
{
    public class EyeCrypto : IEyeCrypto
    {
        private const int saltSize = 16;
        private const int keySize = 16;

        public async Task<byte[]> DecryptAsync(string password, Message message, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using var deriveBytes = new Rfc2898DeriveBytes(password, message.Salt);
            using var decAlg = Aes.Create();
            decAlg.Key = deriveBytes.GetBytes(keySize);
            decAlg.IV = message.Iv;
            await using var ms = new MemoryStream();
            await using var cs = new CryptoStream(ms, decAlg.CreateDecryptor(), CryptoStreamMode.Write);
            await cs.WriteAsync(message.EncryptedData, cancellationToken);
            return ms.ToArray();
        }

        public async Task<Message> EncryptAsync(string password, byte[] rawData, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using var deriveBytes = new Rfc2898DeriveBytes(password, saltSize);
            var salt = deriveBytes.Salt;
            using var encAlg = Aes.Create();
            encAlg.Key = deriveBytes.GetBytes(keySize);
            await using var ms = new MemoryStream();
            await using var cs = new CryptoStream(ms, encAlg.CreateEncryptor(), CryptoStreamMode.Write);
            await cs.WriteAsync(rawData, cancellationToken);
            var message = new Message
            {
                EncryptedData = ms.ToArray(),
                Iv = encAlg.IV,
                Salt = salt
            };
            return message;
        }
    }
}
