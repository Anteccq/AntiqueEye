using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace AntiqueEye.Models
{
    [MessagePackObject]
    public class Block
    {
        [Key(0)]
        public string SiteName { get; set; }
        [Key(1)]
        public string Password { get; set; }
    }
}
