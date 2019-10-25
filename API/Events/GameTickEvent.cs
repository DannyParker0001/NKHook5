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
                    int count = 0;
                    foreach(Bloon b in Game.getBTD5().getBloons())
                    {
                        Logger.Log("Bloon: " + count + " Type: " + b.getType());
                        count++;
                    }
                    Event.Invoke(this, new EventArgs());
                } catch (NullReferenceException) { }
            }
        }
    }
}
