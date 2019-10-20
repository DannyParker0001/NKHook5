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
        int bloonAddr = 0;
        public Bloon(int bloonAddr)
        {
            this.bloonAddr = bloonAddr;
            memlib = Program.memlib;
        }

        /*
         * Getters
         */
        public float getProgress()
        {
            int offset = bloonAddr + 0x26C;
            return memlib.readFloat(offset.ToString("X"));
        }

        /*
         * Setters
         */
        public void setProgress(float progress)
        {
            int offset = bloonAddr + 0x26C;
            memlib.writeMemory(offset.ToString("X"), "float", progress.ToString());
        }
    }
}
