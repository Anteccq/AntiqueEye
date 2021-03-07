using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AntiqueEye.Models.Cryptography
{
    public interface IEyeCrypto
    {
        public Task<Message> EncryptAsync(string password, byte[] rawData, CancellationToken cancellationToken = default);
        public Task<byte[]> DecryptAsync(string password, Message message, CancellationToken cancellationToken = default);
    }
}
