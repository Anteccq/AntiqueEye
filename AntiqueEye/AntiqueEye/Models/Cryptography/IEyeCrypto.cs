using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiqueEye.Models.Cryptography
{
    public interface IEyeCrypto
    {
        public byte[] EncryptAsync(string password, Message message);
        public Message DecryptAsync(string password, byte[] encryptedData);
    }
}
