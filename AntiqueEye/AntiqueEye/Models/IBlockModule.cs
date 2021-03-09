using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AntiqueEye.Models
{
    public interface IBlockModule
    {
        public Task<List<Block>> GetBlocksAsync(string password, CancellationToken cancellationToken = default);

        public Task SetBlocksAsync(string password, List<Block> blocks, CancellationToken cancellationToken = default);
    }
}
