using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5
{
    public class Tower
    {
        Mem memlib;
        int towerAddr = 0;
        public Tower(int towerAddr)
        {
            memlib = Program.memlib;
            this.towerAddr = towerAddr;
        }

        /*
         * Getters
         */
        public int getPoppedBalloons()
        {
            int poppedBloons = towerAddr + 0xEC;
            return memlib.readInt(poppedBloons.ToString("X"));
        }
        public string getMemId()
        {
            return towerAddr.ToString("X");
        }
        public bool isSelected()
        {
            int isSelectedByte = towerAddr + 0xF0;
            if(memlib.readByte(isSelectedByte.ToString("X")) < 1)
            {
                return false;
            }
            return true;
        }
        public bool isSellable()
        {
            int sellableOffset = towerAddr + 0xF0;
            if (memlib.readByte(sellableOffset.ToString("X")) < 1)
            {
                return false;
            }
            return true;
        }

        /*
         * Setters
         */
        public void setPoppedBalloons(int count)
        {
            int poppedBloons = towerAddr + 0xEC;
            memlib.writeMemory(poppedBloons.ToString("X"), "int", count.ToString());
        }
        public void setSelected(bool selected)
        {
            int selectedOffset = towerAddr + 0xF0;
            int value = 0;
            if (selected)
            {
                value = 1;
            }
            memlib.writeMemory(selectedOffset.ToString("X"), "byte", value.ToString());
        }
        public void setSold(bool sold)
        {
            int soldOffset = towerAddr + 0x12C;
            int value = 0;
            if (sold)
            {
                value = 1;
            }
            memlib.writeMemory(soldOffset.ToString("X"), "byte", value.ToString());
        }
        public void setSellable(bool sellable)
        {
            int sellableOffset = towerAddr + 0xF1;
            int value = 0;
            if (sellable)
            {
                value = 1;
            }
            memlib.writeMemory(sellableOffset.ToString("X"), "byte", value.ToString());
        }
    }
}
