using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiqueEye.Models
{
    public interface IBlockModule
    {
        public Task<List<Block>> GetBlocksAsync();

        public Task SetBlocksAsync(List<Block> blocks);
    }
}
