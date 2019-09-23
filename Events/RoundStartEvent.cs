using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5.Events
{
    public class RoundStartEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            int round = 0;
            //Event work
            while (true)
            {
                int newRound = memlib.readInt("BTD5-Win.exe+008844B0,0xC0,0x250,0x8,0x80,0x14");
                if (newRound > round)
                {
                    Event.Invoke(this, new EventArgs());
                }
                round = newRound;
            }
        }
    }
}
