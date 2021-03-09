using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AntiqueEye.Models.Cryptography;

namespace AntiqueEye.Models
{
    public interface IStorage
    {
        public Task<Message> ReadAsync(string path, CancellationToken cancellationToken);

        public Task WriteAsync(string path, Message message, CancellationToken cancellationToken);
    }
}
