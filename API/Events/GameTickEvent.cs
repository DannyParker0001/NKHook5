using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API.Events
{
    public class GameTickEvent : NkEvent
    {
        public static bool cancelled = false;
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            while (true)
            {
                Thread.Sleep(threadDelay);
                if (cancelled) { continue; }
                try
                {
                    foreach (Tower t in Game.getBTD5().getTowers())
                    {
                        if (t.getRotation() > 360.0)
                        {
                            t.setRotation(0);
                            continue;
                        }
                        t.setRotation(t.getRotation() + 1);
                    }
                    Event.Invoke(this, new EventArgs());
                } catch (NullReferenceException) { }
            }
        }
    }
}
