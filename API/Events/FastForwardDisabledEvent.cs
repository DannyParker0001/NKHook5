using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API.Events
{
    public class FastForwardDisabledEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);
            bool result = false;
            //Event work
            while (true)
            {
                Thread.Sleep(threadDelay);
                bool newResult = Game.getBTD5().isFastForwarding();
                if(result != newResult && newResult == false)
                {
                    try
                    {
                        Event.Invoke(this, new EventArgs());
                    }
                    catch (Exception) { }
                }
                result = newResult;
            }
        }
    }
}
