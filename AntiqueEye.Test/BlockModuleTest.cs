using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AntiqueEye.Models;
using AntiqueEye.Models.Cryptography;
using MessagePack;
using static System.Text.Encoding;

namespace AntiqueEye.Test
{
    public class BlockModuleTest
    {
        public class TestEyeCrypto : IEyeCrypto
        {
            public async Task<Message> EncryptAsync(string password, byte[] rawData, CancellationToken cancellationToken = default)
            {
                var message = new Message()
                {
                    EncryptedData = rawData,
                    Iv = UTF8.GetBytes(password),
                    Salt = UTF8.GetBytes(password)
                };
                return message;
            }

            public async Task<byte[]> DecryptAsync(string password, Message message, CancellationToken cancellationToken = default)
            {
                return message.EncryptedData;
            }
        }

        public class TestStorage : IStorage
        {
            public List<Block> TestBlocks { get; } = new List<Block>()
            {
                new() {Password = "Password", SiteName = "SiteName"},
                new () {Password = "drowssap", SiteName = "emaNetiS"},
                new () {Password = "P-c", SiteName = "S-c"},
                new () {Password = "123456789", SiteName = "987654321"},
                new () {Password = " ", SiteName = "  "},
                new () {Password = "", SiteName = ""},
            };

            public async Task<Message> ReadAsync(string path, CancellationToken cancellationToken)
            {
                var data = MessagePackSerializer.Serialize(TestBlocks);
                var message = new Message()
                {
                    EncryptedData = data
                };
                return message;
            }

            public async Task WriteAsync(string path, Message message, CancellationToken cancellationToken)
            {

            }
        }
    }
}
