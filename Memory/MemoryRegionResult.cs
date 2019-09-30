using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Class written by New Age Software
 * NewAge Discord server: https://discord.gg/bVNQNzJ
 * Memory.dll GitHub repository: https://github.com/erfg12/memory.dll
 * This class is protected by the 'DBAD' license: https://dbad-license.org/
 */
namespace Memory
{
    struct MemoryRegionResult
    {
        public UIntPtr CurrentBaseAddress { get; set; }
        public long RegionSize { get; set; }
        public UIntPtr RegionBase { get; set; }

    }
}
