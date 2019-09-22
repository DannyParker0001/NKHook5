using Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NKHook5
{
    internal class Program
    {

        public static Mem memlib = new Mem();

        static void Main(string[] args)
        {
            NKHook5();
        }
        private static void NKHook5()
        {
            Console.Title = "NKHook5-Console";
            Console.WriteLine("NKHook5 Loading...");
            Console.WriteLine("Starting BTD5");
            Process.Start("steam://rungameid/306020");
            Console.WriteLine("Waiting for game...");
            GameWaiter.waitForLoad();
            Console.ReadLine();
        }
        public static void afterGameLoad(Process proc)
        {
            new Game(proc);
            AppDomain.CurrentDomain.ProcessExit += (object sender, EventArgs e) =>
            {
                proc.Kill();
            };
            GameEvents.startHandler(memlib);
            Game.getBTD5().setGameTitle("Bloons TD 5 - Game attached with NKHook5");
            Console.WriteLine("Game hooked & Events registered!");
            Console.WriteLine("Starting memory scanners...");
            MemScanner.startScanners(memlib);
            Console.WriteLine("Started memory scanners!");
            Console.WriteLine("Loading plugins...");
            PluginLoader.loadPlugins();
        }
    }
}
