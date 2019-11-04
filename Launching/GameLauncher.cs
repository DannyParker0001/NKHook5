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
using System.IO;
using NKHook5.WinPE;

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
                string Btd5Dir = SteamUtils.GetGameDir(SteamUtils.BTD5AppID, SteamUtils.BTD5Name);
                Logger.Log("BOOT DEBUG: Install Dir: " + Btd5Dir);
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam\\Apps\\306020");
                if ((int)key.GetValue("Installed") < 1)
                {
                    Logger.Log("BTD5 isnt installed, according to steam.");
                }
                else
                {
                    //string btd5Exe = Btd5Dir + "\\BTD5-Win.exe";
                    string btd5Exe = @"C:\Users\ben\source\repos\InjectionTest\Debug\Payload.dll";

                    byte[] btd5bin = File.ReadAllBytes(btd5Exe);
                    unsafe
                    {
                        fixed (byte* pBin = btd5bin)
                        {
                            PE.DumpExportsFromFile32(pBin);
                        }
                    }

                    
                    
                }
                try
                {
                    while (true)
                    {
                        if ((int)key.GetValue("Running") > 0)
                        {
                            Program.memlib.OpenProcess("BTD5-Win");
                            Program.afterGameLoad(Program.memlib.theProc);
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
