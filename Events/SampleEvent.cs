using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.Events
{
    public class SampleEvent : NkEvent
    {
        //public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            while (true)
            {
                Thread.Sleep(threadDelay);
            }
        }
    }
}
