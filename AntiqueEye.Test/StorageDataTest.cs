using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiqueEye.Models;
using AntiqueEye.Models.Cryptography;
using MessagePack;
using Xunit;
using static System.Text.Encoding;

namespace AntiqueEye.Test
{
    public class StorageDataTest
    {
        [Fact]
        public async Task ReadTest()
        {
            var message = new Message()
            {
                EncryptedData = UTF8.GetBytes("EncryptedData"),
                Iv = UTF8.GetBytes("Iv"),
                Salt = UTF8.GetBytes("Salt")
            };

            string fileName;
            await using (var fs = new FileStream("./testfile", FileMode.Create, FileAccess.Write))
            {
                await MessagePackSerializer.SerializeAsync(fs, message);
                fileName = fs.Name;
            }

            var sd = new StorageData();
            var result = await sd.ReadAsync(fileName);
            result.EncryptedData.Is(message.EncryptedData);
            result.Iv.Is(message.Iv);
            result.Salt.Is(message.Salt);
        }

        [Fact]
        public async Task WriteTest()
        {
            var path = "./testfile_write";
            var message = new Message()
            {
                EncryptedData = UTF8.GetBytes("EncryptedData"),
                Iv = UTF8.GetBytes("Iv"),
                Salt = UTF8.GetBytes("Salt")
            };

            var sd = new StorageData();
            await sd.WriteAsync( path, message);

            var result = await sd.ReadAsync(path);
            result.EncryptedData.Is(message.EncryptedData);
            result.Iv.Is(message.Iv);
            result.Salt.Is(message.Salt);
        }
    }
}
