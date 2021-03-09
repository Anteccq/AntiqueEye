using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AntiqueEye.Models.Cryptography;
using MessagePack;

namespace AntiqueEye.Models
{
    public class StorageData : IStorage
    {
        public async Task<Message> ReadAsync(string path, CancellationToken cancellationToken = default)
        {
            await using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var message = await MessagePackSerializer.DeserializeAsync<Message>(fs, cancellationToken:cancellationToken);
            return message;
        }

        public async Task WriteAsync(string path, Message message, CancellationToken cancellationToken = default)
        {
            await using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            await MessagePackSerializer.SerializeAsync(fs, message, cancellationToken:cancellationToken);
        }
    }
}
