using Memory;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public SizeF getSpriteSize()
        {
            uint offset1 = bloonAddr + 0xA0;
            uint offset2 = bloonAddr + 0xA4;
            SizeF ret = new SizeF(memlib.readFloat(offset1.ToString("X")), memlib.readFloat(offset2.ToString("X")));
            return ret;
        }
        public float getSpriteX()
        {
            uint offset = bloonAddr + 0xA0;
            return memlib.readFloat(offset.ToString("X"));
        }
        public float getSpriteY()
        {
            uint offset = bloonAddr + 0xA4;
            return memlib.readFloat(offset.ToString("X"));
        }
        public float getPosX()
        {
            uint offset = bloonAddr + 0x278;
            return memlib.readFloat(offset.ToString("X"));
        }
        public float getPosY()
        {
            uint offset = bloonAddr + 0x27C;
            return memlib.readFloat(offset.ToString("X"));
        }
        public int getType()
        {
            uint type = bloonAddr + 0x1A8;
            try
            {
                return /*(BloonType)Enum.Parse(typeof(BloonType), */memlib.readInt(type.ToString("X"));//.ToString());
            }
            catch (Exception)
            {
            }
            //return BloonType.ExceptionBloon;
            return 0;
        }

        /*
         * Setters
         */
        public void setProgress(float progress)
        {
            uint offset = bloonAddr + 0x26C;
            memlib.writeMemory(offset.ToString("X"), "float", progress.ToString());
        }
        public void setSpriteSize(SizeF size)
        {
            uint offset1 = bloonAddr + 0xA0;
            uint offset2 = bloonAddr + 0xA4;
            memlib.writeMemory(offset1.ToString("X"), "float", size.Width.ToString());
            memlib.writeMemory(offset2.ToString("X"), "float", size.Height.ToString());
        }
        public void setSpriteX(float sizeX)
        {
            uint offset = bloonAddr + 0xA0;
            memlib.writeMemory(offset.ToString("X"), "float", sizeX.ToString());
        }
        public void setSpriteY(float sizeY)
        {
            uint offset = bloonAddr + 0xA4;
            memlib.writeMemory(offset.ToString("X"), "float", sizeY.ToString());
        }
    }
}
