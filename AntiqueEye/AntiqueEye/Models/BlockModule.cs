using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AntiqueEye.Models.Cryptography;
using MessagePack;

namespace AntiqueEye.Models
{
    public class BlockModule : IBlockModule
    {
        private const string FilePath = "./Notebook";
        private readonly IEyeCrypto _eyeCrypto;
        private readonly IStorage _storage;

        public BlockModule(IEyeCrypto eyeCrypto, IStorage storage)
        {
            _eyeCrypto = eyeCrypto;
            _storage = storage;
        }

        public async Task<List<Block>> GetBlocksAsync(string password, CancellationToken cancellationToken = default)
        {
            var message = await _storage.ReadAsync(FilePath, cancellationToken);
            var decryptedData = await _eyeCrypto.DecryptAsync(password, message, cancellationToken);
            await using var ms = new MemoryStream();
            await ms.WriteAsync(decryptedData.AsMemory(0, decryptedData.Length), cancellationToken);
            var blocks = await MessagePackSerializer.DeserializeAsync<List<Block>>(ms, cancellationToken:cancellationToken);
            return blocks;
        }

        public async Task SetBlocksAsync(string password, List<Block> blocks, CancellationToken cancellationToken = default)
        {
            await using var ms = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(ms, blocks, cancellationToken: cancellationToken);
            var encryptedData = await _eyeCrypto.EncryptAsync(password, ms.ToArray(), cancellationToken);
            await _storage.WriteAsync(FilePath, encryptedData, cancellationToken);
        }
    }
}
