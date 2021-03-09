using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiqueEye.Models.Cryptography;
using Xunit;

namespace AntiqueEye.Test
{
    public class EyeCryptoTest
    {
        [Theory]
        [InlineData("123456789", "passw0rd")]
        [InlineData("123456789 ", "p@ssW0r$")]
        [InlineData("abcdefghijk ", "123456789")]
        [InlineData("AntiqueR ", "Pendulum")]
        [InlineData("", "")]
        public async Task EncryptDecryptTest(string rawText, string password)
        {
            var rawData = Encoding.UTF8.GetBytes(rawText);
            var cry = new EyeCrypto();
            var encrypted = await cry.EncryptAsync(password, rawData);
            var decryptedData = await cry.DecryptAsync(password, encrypted);
            var actualText = Encoding.UTF8.GetString(rawData);
            actualText.Is(rawText);
        }
    }
}
