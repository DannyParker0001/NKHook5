using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5
{
    public class TowerShop
    {
        Mem memlib = Program.memlib;
        private static TowerShop instance;
        public static TowerShop getShop()
        {
            return instance;
        }

        //Tower prices
        static int dartMonkeyAddress = 0;

        internal TowerShop()
        {
            TowerShop.instance = this;

            //scan for tower prices
            dartMonkeyAddress = (int)memlib.AoBScan("0xC8 0x00 0x00 0x00 0x01 0x00 0x00 0x00 0x00 0x00 0x00 0x00", true, true).Result.ToList()[0];
        }

        /*
         * Getters
         */
        public int getDartMonkeyPrice()
        {
            return memlib.readInt(dartMonkeyAddress.ToString("X"));
        }

        /*
         * Setters
         */
        public void setDartMonkeyPrice(int cost)
        {
            memlib.writeMemory(dartMonkeyAddress.ToString("X"), "int", cost.ToString());
        }
    }
}
