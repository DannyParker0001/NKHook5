using NKHook5.Events.Args;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.Events
{
    public class MoneyIncreasedEvent : NkEvent
    {
        public static event EventHandler<MoneyChangedEventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            double money = 0;
            while (true)
            {
                double newMoney = memlib.readDouble("BTD5-Win.exe+008844B0,0xC4,0x90");
                if (newMoney > money)
                {
                    try
                    {
                        MoneyChangedEventArgs args = new MoneyChangedEventArgs(money, newMoney);
                        Event.Invoke(this, args);
                    }
                    catch (NullReferenceException) { }
                }
                money = newMoney;
            }
        }
    }
}
