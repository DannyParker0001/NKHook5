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
    public class MoneyDecreasedEvent : NkEvent
    {
        public static event EventHandler<MoneyChangedEventArgs> Event;

        internal static int cancelQueue = 0;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            double money = 0;
            while (true)
            {
                double newMoney = memlib.readDouble("BTD5-Win.exe+008844B0,0xC4,0x90");
                if (newMoney < money)
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
                            MoneyChangedEventArgs args = new MoneyChangedEventArgs(money, newMoney);
                            Event.Invoke(this, args);
                        }
                        catch (NullReferenceException) { }
                    }
                }
                money = newMoney;
            }
        }
    }
}
