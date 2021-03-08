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
        public void EncryptDecryptTest(string rawData, string password)
        {

        }
    }
}
