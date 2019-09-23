using Memory;
using NKHook5.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5
{
    internal class MemScanner
    {
        private static Mem memlib;

        public static List<int> selectedTowers = new List<int>();
        public static List<int> hoveredTowers = new List<int>();
        public static List<int> allTowers = new List<int>();

        public static List<int> hoveredCache = new List<int>();

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
                List<int> towerResult = new List<int>();
                List<int> hoverList = new List<int>();
                List<int> selectedList = new List<int>();
                foreach (int tower in allTowers)
                {
                    try
                    {
                        int soldCheck = tower + 0x12C;
                        if (memlib.readByte(soldCheck.ToString("X")) < 1)
                        {
                            towerResult.Add(tower);
                            int hoverCheck = tower + 0x215;
                            int selectedCheck = tower + 0xF0;
                            if (memlib.readByte(hoverCheck.ToString("X")) > 0)
                            {
                                hoverList.Add(tower);
                            }
                            int selectedValue = memlib.readByte(selectedCheck.ToString("X"));
                            if (selectedValue == 1)
                            {
                                selectedList.Add(tower);
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
                List<long> scanResult = memlib.AoBScan("0? 01 00 01 01 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ??", true, true).Result.ToList();
                List<int> towerResult = new List<int>();
                hoveredTowers = new List<int>();
                selectedTowers = new List<int>();
                foreach (long result in scanResult)
                {
                    try
                    {
                        int baseV = (int)result & int.MaxValue;
                        string hexS = baseV.ToString("X");
                        int hexI = int.Parse(hexS, System.Globalization.NumberStyles.HexNumber);
                        hexI -= 0xF0;
                        int soldCheck = hexI + 0x12C;
                        if (memlib.readByte(soldCheck.ToString("X")) < 1)
                        {
                            towerResult.Add(hexI);
                            int hoverCheck = hexI + 0x215;
                            int selectedCheck = hexI + 0xF0;
                            if (memlib.readByte(hoverCheck.ToString("X")) > 0)
                            {
                                hoveredTowers.Add(hexI);
                            }
                            if (memlib.readByte(selectedCheck.ToString("X")) > 0)
                            {
                                selectedTowers.Add(hexI);
                            }
                        }
                    }
                    catch (OverflowException) { }
                }
                allTowers = towerResult;
                Thread.Sleep(1000);
                GameTickEvent.cancelled = false;
            }
        }
    }
}
