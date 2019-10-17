using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API
{
    public class TowerShop
    {
        Mem memlib = Program.memlib;
        private static TowerShop instance;
        public static TowerShop getShop()
        {
            return instance;
        }

        internal TowerShop()
        {
            TowerShop.instance = this;
        }

        /*
         * Getters
         */
        public int getDartMonkeyPrice()
        {
            int offset = 196;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getTackShooterPrice()
        {
            int offset = 200;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getSniperMonkeyPrice()
        {
            int offset = 175;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getBoomerangMonkeyPrice()
        {
            int offset = 130;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getNinjaMonkeyPrice()
        {
            int offset = 210;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        /*
         * Couldnt find bomb tower offset yet :(
         */
        public int getIceTowerPrice()
        {
            int offset = 236;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getGlueGunnerPrice()
        {
            int offset = 70;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getMonkeySailorPrice()
        {
            int offset = 110;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getMonkeyPilotPrice()
        {
            int offset = 105;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getSuperMonkeyPrice()
        {
            int offset = 136;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getMonkeyApprenticePrice()
        {
            int offset = 61;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getMonkeyVillagePrice()
        {
            int offset = 151;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getBananaFarmPrice()
        {
            int offset = 121;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getMortarTowerPrice()
        {
            int offset = 156;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getDartlingGunPrice()
        {
            int offset = 151;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getSpikeFactoryPrice(int cost)
        {
            int offset = 246;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        /*
         * Heli & engi here
         */
        public int getBloonChipperPrice()
        {
            int offset = 111;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }
        public int getMonkeySubPrice()
        {
            int offset = 191;
            return memlib.readInt("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34");
        }

        /*
         * Setters
         */
        public void setDartMonkeyPrice(int cost)
        {
            int offset = 0xC4;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setTackShooterPrice(int cost)
        {
            int offset = 0xC8;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setSniperMonkeyPrice(int cost)
        {
            int offset = 0x170;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setBoomerangMonkeyPrice(int cost)
        {
            int offset = 0x128;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setNinjaMonkeyPrice(int cost)
        {
            int offset = 0xD0;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setBombTowerPrice(int cost)
        {
            int offset = 0x1E8;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setIceTowerPrice(int cost)
        {
            int offset = 0xEC;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setGlueGunnerPrice(int cost)
        {
            int offset = 0x40;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setMonkeySailorPrice(int cost)
        {
            int offset = 0x70;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setMonkeyPilotPrice(int cost)
        {
            int offset = 0x100;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setSuperMonkeyPrice(int cost)
        {
            int offset = 0x130;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setMonkeyApprenticePrice(int cost)
        {
            int offset = 0x38;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setMonkeyVillagePrice(int cost)
        {
            int offset = 0x14C;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setBananaFarmPrice(int cost)
        {
            int offset = 0x118;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setMortarTowerPrice(int cost)
        {
            int offset = 0x154;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setDartlingGunPrice(int cost)
        {
            int offset = 0x150;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setSpikeFactoryPrice(int cost)
        {
            int offset = 0xF0;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setMonkeyEngineerPrice(int cost)
        {
            int offset = 0x1C8;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setHeliPilotPrice(int cost)
        {
            int offset = 0x1D4;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setBloonChipperPrice(int cost)
        {
            int offset = 0x108;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
        public void setMonkeySubPrice(int cost)
        {
            int offset = 0xB8;
            memlib.writeMemory("BTD5-Win.exe+008844B0,9C,30,C," + offset.ToString("X") + ",4,20,34", "int", cost.ToString());
        }
    }
}
