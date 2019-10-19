﻿using Memory;
using NKHook5.API.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5.API
{
    public class Game
    {
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        static Game instance = null;
        internal static System.Diagnostics.Process gameProc = null;
        static Mem memlib = Program.memlib;

        public static Game getBTD5()
        {
            return instance;
        }
        public static System.Diagnostics.Process getProcess()
        {
            return gameProc;
        }
        internal Game(System.Diagnostics.Process gameProc)
        {
            Game.gameProc = gameProc;
            instance = this;
        }

        /*
         * Getters here
         */
        public List<Tower> getTowers()
        {
            List<Tower> allTowers = new List<Tower>();
            int amount = memlib.readInt("BTD5-Win.exe+008844B0,D8,5AC");
            //Logger.Log(int.Parse(memlib.getCode("BTD5-Win.exe+008844B0,78,3C,0,0").ToString()).ToString("X"));
            for (int i = 0; i < (amount * 0x4); i += 0x4)
            {
                allTowers.Add(new Tower(int.Parse(memlib.getCode("BTD5-Win.exe+008844B0,78,3C," + i.ToString("X") + ",0").ToString())));
            }
            return allTowers;
        }
        public Tower getSelectedTower()
        {
            try
            {
                foreach (Tower tower in getTowers())
                {
                    if (tower.isSelected())
                    {
                        return tower;
                    }
                }
            }
            catch (InvalidOperationException) { }
            return null;
        }
        public double getMoney()
        {
            return memlib.readDouble("BTD5-Win.exe+008844B0,0xC4,0x90");
        }
        public int getMonkeyMoney()
        {
            return memlib.readInt("BTD5-Win.exe+008844B0,0xD4,0x18,0x0,0x58,0x118");
        }
        public int getTokens()
        {
            return memlib.readInt("BTD5-Win.exe+008844B0,0xD4,0x18,0x0,0x58,0x120");
        }
        public int getHealth()
        {
            return memlib.readInt("BTD5-Win.exe+00884274,0x5C,0x8C,0x18,0xC8,0x88");
        }
        public int getRound()
        {
            return memlib.readInt("BTD5-Win.exe+008844B0,0xC0,0x250,0x8,0x80,0x14");
        }
        public int getRank()
        {
            return memlib.readInt("BTD5-Win.exe+008844B0,0xF0,0x0,0xC4,0x20");
        }
        public int getXP()
        {
            return memlib.readInt("BTD5-Win.exe+008844B0,0xD4,0x18,0x0,0x58,0x28");
        }
        public float getMouseX()
        {
            return memlib.readFloat("BTD5-Win.exe+00884438,0x10,0x20");
        }
        public float getMouseY()
        {
            return memlib.readFloat("BTD5-Win.exe+008844B0,0x8,0x24");
        }
        public int getScreenMouseX()
        {
            return memlib.readInt("gameoverlayrenderer.dll+1256B8");
        }
        public int getScreenMouseY()
        {
            return memlib.readInt("gameoverlayrenderer.dll+1256BC");
        }
        public int getDoublePathCutoff()
        {
            return memlib.readByte("BTD5-Win.exe+3C8DC9");
        }

        /*
         * Setters here
         */
        public void setGameTitle(string title)
        {
            SetWindowText(gameProc.MainWindowHandle, title);
        }
        public void setMoney(double amount)
        {
            if(amount>getMoney())
            {
                MoneyIncreasedEvent.cancelQueue++;
            }
            if(amount<getMoney())
            {
                MoneyDecreasedEvent.cancelQueue++;
            }
            MoneyChangedEvent.cancelQueue++;
            memlib.writeMemory("BTD5-Win.exe+008844B0,0xC4,0x90", "double", amount.ToString());
        }
        public void setMonkeyMoney(int amount)
        {
            memlib.writeMemory("BTD5-Win.exe+008844B0,0xD4,0x18,0x0,0x58,0x118", "int", amount.ToString());
        }
        public void setTokens(int amount)
        {
            memlib.writeMemory("BTD5-Win.exe+008844B0,0xD4,0x18,0x0,0x58,0x120", "int", amount.ToString());
        }
        public void setHealth(int amount)
        {
            memlib.writeMemory("BTD5-Win.exe+00884274,0x5C,0x8C,0x18,0xC8,0x88", "int", amount.ToString());
        }
        public void setRound(int round)
        {
            memlib.writeMemory("BTD5-Win.exe+008844B0,0xC0,0x250,0x8,0x80,0x14", "int", round.ToString());
        }
        public void setRank(int rank)
        {
            memlib.writeMemory("BTD5-Win.exe+008844B0,0xF0,0x0,0xC4,0x20", "int", rank.ToString());
        }
        public void setXP(double xp)
        {
            memlib.writeMemory("BTD5-Win.exe+008844B0,0xD4,0x18,0x0,0x58,0x28", "double", xp.ToString());
        }
        public void setDoublePathCutoff(int maxCutoff)
        {
            memlib.writeMemory("BTD5-Win.exe+3C8DC9", "byte", maxCutoff.ToString());
        }

        /*
         * Game functions
         */
        public void safeExit()
        {
            gameProc.Close();
        }
        public void killGame()
        {
            gameProc.Kill();
        }
    }
}
