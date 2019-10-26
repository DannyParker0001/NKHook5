using Btd6Launcher.Steam;
using Microsoft.Win32;
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
        internal static void launchProperly()
        {
            BackgroundWorker gameWaitWorker = new BackgroundWorker();
            gameWaitWorker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Waiting for game...");
                Logger.Log("BOOT DEBUG: Install Dir: " + SteamUtils.GetGameDir(SteamUtils.BTD5AppID, SteamUtils.BTD5Name));
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam\\Apps\\306020");
                if((int)key.GetValue("Installed") < 1)
                {
                    Logger.Log("BTD5 isnt installed, according to steam.");
                }
                try
                {
                    while (true)
                    {
                        if ((int)key.GetValue("Running") > 0)
                        {
                            Program.memlib.OpenProcess("BTD5-Win");
                            Program.afterGameLoad(System.Diagnostics.Process.GetProcessesByName("BTD5-Win")[0]);
                            break;
                        }
                        else
                        {
                            Process.Start("steam://rungameid/306020");
                            Thread.Sleep(5000);
                        }
                    }
                }
                catch (Exception)
                {
                    Logger.Log("An exception occoured when starting, hooking or checking if the game is running. This could mean you dont have BTD5 installed via steam or there is a bug.");
                }
            };
            gameWaitWorker.RunWorkerAsync();
        }
    }
}
