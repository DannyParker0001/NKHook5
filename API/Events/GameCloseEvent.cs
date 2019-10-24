using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API.Events
{
    public class GameCloseEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            while (true)
            {
                Thread.Sleep(threadDelay);
                if(Game.getBTD5().getWindowSize().Width==0&& Game.getBTD5().getWindowSize().Height == 0&& Game.getBTD5().getWindowLocation().X==0 && Game.getBTD5().getWindowLocation().Y == 0)
                {
                    try
                    {
                        Event.Invoke(this, new EventArgs());
                    } catch (Exception) { }
                }
            }
        }
    }
}
