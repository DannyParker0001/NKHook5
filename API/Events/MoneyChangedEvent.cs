using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API.Events
{
    public class MoneyChangedEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;

        internal static int cancelQueue = 0;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            double money = 0;
            //Event work
            while (true)
            {
                Thread.Sleep(threadDelay);
                double newMoney = memlib.readDouble("BTD5-Win.exe+008844B0,0xC4,0x90");
                if(newMoney != money)
                {
                    if (cancelQueue > 0)
                    {
                        cancelQueue--;
                        continue;
                    }
                    else
                    {
                        try
                        {
                            Event.Invoke(this, new EventArgs());
                        }
                        catch (NullReferenceException) { }
                    }
                }
                money = newMoney;
            }
        }
    }
}
