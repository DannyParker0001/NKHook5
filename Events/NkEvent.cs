using System;
using Memory;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NKHook5.Events
{
    public class NkEvent
    {
        public static int threadDelay = 10;
        public static NkEvent nkEvent;
        public static Mem memlib = Program.memlib;
        public void startAsync()
        {
            BackgroundWorker EventWorker = new BackgroundWorker();
            EventWorker.DoWork += work;
            EventWorker.RunWorkerAsync();
            nkEvent = this;
        }
        public virtual void work(object sender, DoWorkEventArgs e)
        {
        }
    }
}
