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
        public int getPosX()
        {
            int xOffset = towerAddr + 0x92;
            return memlib.readInt(xOffset.ToString("X"));
        }
        public int getPosY()
        {
            int yOffset = towerAddr + 0x96;
            return memlib.readInt(yOffset.ToString("X"));
        }
        public int getUpgrades(Path p)
        {
            if (p.Equals(Path.Left))
            {
                int path1 = towerAddr + 0x138;
                return memlib.readInt(path1.ToString("X"));
            }
            else
            {
                int path2 = towerAddr + 0x13C;
                return memlib.readInt(path2.ToString("X"));
            }
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
        public void setPosX(int x)
        {
            int xOffset = towerAddr + 0x92;
            memlib.writeMemory(xOffset.ToString("X"), "int", x.ToString());
        }
        public void setPosY(int y)
        {
            int yOffset = towerAddr + 0x96;
            memlib.writeMemory(yOffset.ToString("X"), "int", y.ToString());
        }
        public void setUpgrades(Path p, int upgrade)
        {
            if (p.Equals(Path.Left))
            {
                int path1 = towerAddr + 0x138;
                memlib.writeMemory(path1.ToString("X"), "int", upgrade.ToString());
            }
            else
            {
                int path2 = towerAddr + 0x13C;
                memlib.writeMemory(path2.ToString("X"), "int", upgrade.ToString());
            }
        }

        /*
         * Selectors/Enums
         */
        public enum Path
        {
            Left,
            Right
        }
    }
}
