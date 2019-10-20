using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5.API
{
    public class Bloon
    {
        Mem memlib;
        uint bloonAddr = 0;
        public Bloon(uint bloonAddr)
        {
            this.bloonAddr = bloonAddr;
            memlib = Program.memlib;
        }

        /*
         * Getters
         */
        public float getProgress()
        {
            uint offset = bloonAddr + 0x26C;
            return memlib.readFloat(offset.ToString("X"));
        }

        /*
         * Setters
         */
        public void setProgress(float progress)
        {
            uint offset = bloonAddr + 0x26C;
            memlib.writeMemory(offset.ToString("X"), "float", progress.ToString());
        }
    }
}
