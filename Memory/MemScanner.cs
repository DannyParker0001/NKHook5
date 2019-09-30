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

        public static List<int> selectedTowers = new List<int>();
        public static List<int> hoveredTowers = new List<int>();
        public static List<int> allTowers = new List<int>();

        public static List<int> hoveredCache = new List<int>();
        public static List<int> badCache = new List<int>();

        static BackgroundWorker scanWorker = new BackgroundWorker();
        static BackgroundWorker validateWorker = new BackgroundWorker();

        public static void startScanners(Mem lib)
        {
            memlib = lib;
            scanWorker.DoWork += scan;
            if (!scanWorker.IsBusy)
            {
                scanWorker.RunWorkerAsync();
            }
            validateWorker.DoWork += validateTowers;
            if (!validateWorker.IsBusy)
            {
                validateWorker.RunWorkerAsync();
            }

            //check if game is loading
            MapLoadEvent.Event += resetAll;
            //check if screen status changes for first time to cache bad tower addresses
            ScreenOpenEvent.Event += storeBadCache;
        }

        //cache the bad towers
        static bool need2Cache = true;
        private static void storeBadCache(object sender, EventArgs e)
        {
            if (need2Cache)
            {
                Logger.Log("CACHING BAD TOWERS ADDRESSES! DO NOT DO ANYTHING UNTIL FINISHED!");
                Thread.Sleep(4000);
                List<long> scanResult = memlib.AoBScan("98 FB CF 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00", true, true).Result.ToList();
                foreach(long result in scanResult)
                {
                    if(!badCache.Contains((int)result))
                        badCache.Add((int)result);
                }
                Logger.Log("Caching complete!");
                need2Cache = false;
            }
        }

        private static void resetAll(object sender, EventArgs e)
        {
            GameTickEvent.cancelled = true;
            Logger.Log("Map is loading, cleaning load garbage...");
            foreach(Tower toGC in Game.getBTD5().getTowers())
            {
                toGC.setSelected(false);
                toGC.setSold(true);
            }
            Game.getBTD5().setGameTitle("NKHook5");
            Logger.Log("Cleaned up load garbage");
            GameTickEvent.cancelled = false;
        }

        public static int getHoveredTower()
        {
            if (hoveredCache.Count > 0)
            {
                foreach (int tower in hoveredCache)
                {
                    int hoverCheck = tower + 0x215;
                    if (memlib.readByte(hoverCheck.ToString("X")) > 0)
                    {
                        return tower;
                    }
                }
            }
            return 0;
        }

        private static void validateTowers(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(50);
                List<int> hoverList = new List<int>();
                List<int> selectedList = new List<int>();
                foreach (int tower in allTowers)
                {
                    try
                    {
                        int validCheck = tower + 0x14;
                        int validCheck2 = tower + 0x38;
                        int validCheck3 = tower + 0x48;
                        int soldCheck = tower + 0x12C;
                        int hoverCheck = tower + 0x215;
                        int selectedCheck = tower + 0xF0;
                        if (memlib.readInt(validCheck.ToString("X")) > 0 && memlib.readInt(validCheck2.ToString("X")) > 0 && memlib.readInt(validCheck3.ToString("X")) > 0)
                        {
                            if (memlib.readByte(soldCheck.ToString("X")) < 1)
                            {
                                allTowers.Add(tower);
                                if (memlib.readByte(hoverCheck.ToString("X")) > 0)
                                {
                                    hoveredTowers.Add(tower);
                                }
                                if (memlib.readByte(selectedCheck.ToString("X")) > 0)
                                {
                                    selectedTowers.Add(tower);
                                }
                            }
                        }
                    }
                    catch (OverflowException) { }
                    hoveredTowers = hoverList;
                    selectedTowers = selectedList;
                }
            }
        }
        private static void scan(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(5000);
                GameTickEvent.cancelled = true;
                List<long> scanResult = memlib.AoBScan("98 FB CF 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00", true, true).Result.ToList();
                hoveredTowers = new List<int>();
                selectedTowers = new List<int>();
                allTowers = new List<int>();
                List<int> invalidTowers = new List<int>();
                foreach (long result in scanResult)
                {
                    try
                    {
                        int tower = int.Parse(result.ToString("X"), System.Globalization.NumberStyles.HexNumber);
                        //Check if its cached as bad, dont even bother doing anything else.
                        if (badCache.Contains(tower))
                        {
                            continue;
                        }
                        int validCheck = tower + 0x14;
                        int validCheck2 = tower + 0x38;
                        int validCheck3 = tower + 0x48;
                        int soldCheck = tower + 0x12C;
                        int hoverCheck = tower + 0x215;
                        int selectedCheck = tower + 0xF0;
                        if (memlib.readInt(validCheck.ToString("X")) > 0 && memlib.readInt(validCheck2.ToString("X")) > 0 && memlib.readLong(validCheck3.ToString("X")) > 0)
                        {
                            if (memlib.readByte(soldCheck.ToString("X")) < 1)
                            {
                                allTowers.Add(tower);
                                if (memlib.readByte(hoverCheck.ToString("X")) > 0)
                                {
                                    hoveredTowers.Add(tower);
                                }
                                if (memlib.readByte(selectedCheck.ToString("X")) > 0)
                                {
                                    selectedTowers.Add(tower);
                                    Logger.Log(tower.ToString("X"));
                                }
                            }
                        }
                        else
                        {
                            invalidTowers.Add(tower);
                        }
                    }
                    catch (OverflowException) { }
                }
                Thread.Sleep(1000);
                GameTickEvent.cancelled = false;
            }
        }
    }
}
