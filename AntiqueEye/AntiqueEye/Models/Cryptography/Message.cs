using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace AntiqueEye.Models.Cryptography
{
    [MessagePackObject]
    public class Message
    {
        [Key(0)]
        public byte[] EncryptedData { get; set; }
        [Key(1)]
        public byte[] Iv { get; set; }
        [Key(2)]
        public byte[] Salt { get; set; }
    }
}
