using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiqueEye.Models.Cryptography
{
    public interface IEyeCrypto
    {
        public Message EncryptAsync(string password, byte[] rawData);
        public byte[] DecryptAsync(string password, Message message);
    }
}
