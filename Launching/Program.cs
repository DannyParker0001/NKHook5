using DiscordRPC;
using Memory;
using NKHook5.API;
using NKHook5.API.Events;
using NKHook5.NKHookGDI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
        internal static DiscordRpcClient client = new DiscordRpcClient("636315850630234139");

        static void Main(string[] args)
        {
            NKHook5();
        }
        private static void NKHook5()
        {
            Console.Title = "NKHook5-Console";
            Console.WriteLine("NKHook5 (Unstable 7) Loading...");
            if(!new FileInfo(Environment.CurrentDirectory+ "\\Newtonsoft.Json.dll").Exists)
            {
                WebClient client = new WebClient();
                client.DownloadFile("LINK TBD", Environment.CurrentDirectory + "\\Newtonsoft.Json.dll");
            }
            client.UpdateDetails("NKHook is loading...");
            Console.WriteLine("NKHook Discord: https://discord.gg/VADMF2M");
            Console.WriteLine("Thanks to NewAgeSoftware for providing an API for memory hacking.");
            Console.WriteLine("More info can be found at: https://github.com/erfg12/memory.dll");
            AppDomain.CurrentDomain.ProcessExit += new EventHandler((object sender, EventArgs e) =>
            {
                Game.getBTD5().killGame();
            });
            GameLauncher.launchProperly();
            Console.ReadLine();
        }
        public static void afterGameLoad(Process proc)
        {
            new Game(proc);
            GameEvents.startHandler(memlib);
            new TowerShop();
            Game.getBTD5().setGameTitle("Bloons TD 5 - Game attached with NKHook5");
            Console.WriteLine("Game hooked & Events registered!");
            Console.WriteLine("Loading plugins...");
            PluginLoader.loadPlugins();
            List<long> res = memlib.AoBScan("68 74 74 70 73 3A 2F 2F 6E 65 77 67 61 6D 2E 65 73 2F 62 74 64 35 62 74 64 36", true, true).Result.ToList();
            foreach (long addr in res)
            {
                memlib.writeMemory(addr.ToString("X"), "string", "https://discord.gg/VADMF2M");
            }
            NKGDI gdi = new NKGDI(memlib);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.Run(gdi);
            client.UpdateDetails("NKHook was just hooked to BTD5");
        }
    }
}
