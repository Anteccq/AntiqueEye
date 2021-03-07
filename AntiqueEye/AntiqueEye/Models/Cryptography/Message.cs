using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiqueEye.Models.Cryptography
{
    public class Message
    {
        public byte[] EncryptedData { get; set; }
        public byte[] Iv { get; set; }
    }
}
