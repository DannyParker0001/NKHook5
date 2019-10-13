using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.Events
{
    public class MouseUpEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            int clickCount = 0;
            while (true)
            {
                Thread.Sleep(threadDelay);
                int newCount = memlib.readInt("BTD5-Win.exe+88436C");
                if(clickCount < newCount)
                {
                    try
                    {
                        Event.Invoke(this, new EventArgs());
                    }
                    catch (NullReferenceException) { }
                }
                clickCount = newCount;
            }
        }
    }
}
