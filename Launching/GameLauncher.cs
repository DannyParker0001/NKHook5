using Btd6Launcher.Steam;
using NKHook5.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5
{
    internal class GameLauncher
    {
        public static void waitForLoad()
        {
            BackgroundWorker gameWaitWorker = new BackgroundWorker();
            gameWaitWorker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                Thread.Sleep(1000);
                while (true)
                {
                    System.Diagnostics.Process[] procs = Process.GetProcessesByName("BTD5-Win");
                    if (procs.Length > 0)
                    {
                        Thread.Sleep(5000);
                        Program.memlib.OpenProcess("BTD5-Win");
                        Program.afterGameLoad(Process.GetProcessesByName("BTD5-Win")[0]);
                        break;
                    }
                }
            };
            gameWaitWorker.RunWorkerAsync();
        }

        internal static void launchProperly()
        {
            BackgroundWorker gameWaitWorker = new BackgroundWorker();
            gameWaitWorker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Waiting for game...");
                Logger.Log("BOOT DEBUG: Install Dir: " + SteamUtils.GetGameDir(SteamUtils.BTD5AppID, SteamUtils.BTD5Name));
                while (true)
                {
                    System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName("BTD5-Win");
                    if (procs.Length > 0)
                    {
                        Thread.Sleep(5000);
                        Program.memlib.OpenProcess("BTD5-Win");
                        Program.afterGameLoad(System.Diagnostics.Process.GetProcessesByName("BTD5-Win")[0]);
                        break;
                    }
                    System.Diagnostics.Process.Start("steam://rungameid/306020");
                }
                Logger.Log("BTD5 cant be found running");
                Console.WriteLine("Starting BTD5");
            };
            gameWaitWorker.RunWorkerAsync();
        }
    }
}
