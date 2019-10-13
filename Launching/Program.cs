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
    /*
     * NKHook5
     * All code under the NKHook (NKHook.*) namespace is protected by LGPL-3.0
     * More info can be found here: https://www.gnu.org/licenses/lgpl-3.0.en.html
     * The license can be changed at any time
     * In an event as such any previous code written under a previous license will
     * be subject to the new license.
     */
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
            Console.WriteLine("NKHook5 (Unstable 4) Loading...");
            Console.WriteLine("NKHook Discord: https://discord.gg/VADMF2M");
            Console.WriteLine("Thanks to NewAgeSoftware for providing an API for memory hacking.");
            Console.WriteLine("More info can be found at: https://github.com/erfg12/memory.dll");
            GameLauncher.launchProperly();
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
            new TowerShop();
            Game.getBTD5().setGameTitle("Bloons TD 5 - Game attached with NKHook5");
            Console.WriteLine("Game hooked & Events registered!");
            Console.WriteLine("Loading plugins...");
            PluginLoader.loadPlugins();
        }
    }
}
