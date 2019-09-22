using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.Events
{
    public class MapLoadEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        static UIntPtr moneyAddress = memlib.getCode("BTD5-Win.exe+008844B0,0xC4,0x90");
        static UIntPtr healthAddress = memlib.getCode("BTD5-Win.exe+00884274,0x5C,0x8C,0x18,0xC8,0x88");
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            while (true)
            {
                Thread.Sleep(50);
                UIntPtr newMoneyAddress = memlib.getCode("BTD5-Win.exe+008844B0,0xC4,0x90");
                UIntPtr newHealthAddress = memlib.getCode("BTD5-Win.exe+00884274,0x5C,0x8C,0x18,0xC8,0x88");
                if (newMoneyAddress != moneyAddress & newHealthAddress != healthAddress)
                {
                    try
                    {
                        Event.Invoke(null, new EventArgs());
                    }
                    catch (NullReferenceException) { }
                }
                moneyAddress = newHealthAddress;
                healthAddress = newHealthAddress;
            }
        }
    }
}
