using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5.Events
{
    public class MoneyIncreasedEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            while (true)
            {
                double money = 0;
                //Event work
                while (true)
                {
                    double newMoney = memlib.readDouble("BTD5-Win.exe+008844B0,0xC4,0x90");
                    if (newMoney > money)
                    {
                        try
                        {
                            Event.Invoke(this, new EventArgs());
                        }
                        catch (NullReferenceException) { }
                    }
                    money = newMoney;
                }
            }
        }
    }
}
