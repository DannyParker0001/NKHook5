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
    internal class GameWaiter
    {
        public static void waitForLoad()
        {
            BackgroundWorker gameWaitWorker = new BackgroundWorker();
            gameWaitWorker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                Thread.Sleep(1000);
                while (true)
                {
                    Process[] procs = Process.GetProcessesByName("BTD5-Win");
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
    }
}
