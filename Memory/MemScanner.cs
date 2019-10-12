using Memory;
using NKHook5.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Class written by New Age Software
 * NewAge Discord server: https://discord.gg/bVNQNzJ
 * Memory.dll GitHub repository: https://github.com/erfg12/memory.dll
 */
namespace NKHook5
{
    internal class MemScanner
    {
        private static Mem memlib;

        public static List<int> allTowers = new List<int>();

        public static void startScanners(Mem lib)
        {
            memlib = lib;
            //check if game is loading
            MapLoadEvent.Event += resetAll;
        }

        private static void resetAll(object sender, EventArgs e)
        {
            scanTowers();
        }

        internal static void scanTowers()
        {
            scanTowers(memlib.readInt("BTD5-Win.exe+008844B0,D8,5AC"));
        }
        internal static void scanTowers(int amount)
        {
            allTowers = new List<int>();
            //Logger.Log(int.Parse(memlib.getCode("BTD5-Win.exe+008844B0,78,3C,0,0").ToString()).ToString("X"));
            for(int i = 0; i<amount; i+=0x4)
            {
                allTowers.Add(int.Parse(memlib.getCode("BTD5-Win.exe+008844B0,78,3C," + i.ToString("X") + ",0").ToString()));
            }
        }
    }
}
