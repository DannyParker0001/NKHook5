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
        static int tackShooterAddress = 0;
        static int sniperMonkeyAddress = 0;
        static int boomerangMonkeyAddress = 0;
        static int ninjaMonkeyAddress = 0;
        static int bombTowerAddress = 0;
        static int iceTowerAddress = 0;
        static int glueGunnerAddress = 0;
        static int monkeySailorAddress = 0;
        static int monkeyPilotAddress = 0;

        internal TowerShop()
        {
            TowerShop.instance = this;

            //scan for tower prices
            dartMonkeyAddress = (int)memlib.AoBScan("0xC8 0x00 0x00 0x00 0x01", true, true).Result.ToList()[0];
            tackShooterAddress = (int)memlib.AoBScan("0x68 0x01 0x00 0x00 0x02", true, true).Result.ToList()[0];
            sniperMonkeyAddress = (int)memlib.AoBScan("0x5E 0x01 0x00 0x00 0x03", true, true).Result.ToList()[0];
            boomerangMonkeyAddress = (int)memlib.AoBScan("0x90 0x01 0x00 0x00 0x04", true, true).Result.ToList()[0];
            ninjaMonkeyAddress = (int)memlib.AoBScan("0xF4 0x01 0x00 0x00 0x06", true, true).Result.ToList()[0];
            bombTowerAddress = (int)memlib.AoBScan("0x8A 0x02 0x00 0x00 0x07", true, true).Result.ToList()[0];
            iceTowerAddress = (int)memlib.AoBScan("0x2C 0x01 0x00 0x00 0x08", true, true).Result.ToList()[0];
            glueGunnerAddress = (int)memlib.AoBScan("0x0E 0x01 0x00 0x00 0x09", true, true).Result.ToList()[0];
            monkeySailorAddress = (int)memlib.AoBScan("0x0D 0x02 0x00 0x00 0x0B", true, true).Result.ToList()[0];
            monkeyPilotAddress = (int)memlib.AoBScan("0x9D 0x03 0x00 0x00 0x0C", true, true).Result.ToList()[0];
        }

        /*
         * Getters
         */
        public int getDartMonkeyPrice()
        {
            return memlib.readInt(dartMonkeyAddress.ToString("X"));
        }
        public int getTackShooterPrice()
        {
            return memlib.readInt(tackShooterAddress.ToString("X"));
        }
        public int getSniperMonkeyPrice()
        {
            return memlib.readInt(sniperMonkeyAddress.ToString("X"));
        }
        public int getBoomerangMonkeyPrice()
        {
            return memlib.readInt(boomerangMonkeyAddress.ToString("X"));
        }
        public int getNinjaMonkeyPrice()
        {
            return memlib.readInt(ninjaMonkeyAddress.ToString("X"));
        }
        public int getBombTowerPrice()
        {
            return memlib.readInt(bombTowerAddress.ToString("X"));
        }
        public int getIceTowerPrice()
        {
            return memlib.readInt(iceTowerAddress.ToString("X"));
        }
        public int getGlueGunnerPrice()
        {
            return memlib.readInt(glueGunnerAddress.ToString("X"));
        }
        public int getMonkeySailorPrice()
        {
            return memlib.readInt(monkeySailorAddress.ToString("X"));
        }
        public int getMonkeyPilotPrice()
        {
            return memlib.readInt(monkeyPilotAddress.ToString("X"));
        }

        /*
         * Setters
         */
        public void setDartMonkeyPrice(int cost)
        {
            memlib.writeMemory(dartMonkeyAddress.ToString("X"), "int", cost.ToString());
        }
        public void setTackShooterPrice(int cost)
        {
            memlib.writeMemory(tackShooterAddress.ToString("X"), "int", cost.ToString());
        }
        public void setSniperMonkeyPrice(int cost)
        {
            memlib.writeMemory(sniperMonkeyAddress.ToString("X"), "int", cost.ToString());
        }
        public void setBoomerangMonkeyPrice(int cost)
        {
            memlib.writeMemory(boomerangMonkeyAddress.ToString("X"), "int", cost.ToString());
        }
        public void setNinjaMonkeyPrice(int cost)
        {
            memlib.writeMemory(ninjaMonkeyAddress.ToString("X"), "int", cost.ToString());
        }
        public void setBombTowerPrice(int cost)
        {
            memlib.writeMemory(bombTowerAddress.ToString("X"), "int", cost.ToString());
        }
        public void setIceTowerPrice(int cost)
        {
            memlib.writeMemory(iceTowerAddress.ToString("X"), "int", cost.ToString());
        }
        public void setGlueGunnerPrice(int cost)
        {
            memlib.writeMemory(glueGunnerAddress.ToString("X"), "int", cost.ToString());
        }
        public void setMonkeySailorPrice(int cost)
        {
            memlib.writeMemory(monkeySailorAddress.ToString("X"), "int", cost.ToString());
        }
        public void setMonkeyPilotPrice(int cost)
        {
            memlib.writeMemory(monkeyPilotAddress.ToString("X"), "int", cost.ToString());
        }
    }
}
