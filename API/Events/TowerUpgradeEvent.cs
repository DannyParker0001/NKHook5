using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API.Events
{
    class TowerUpgradeEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            byte oldVal = (byte)(memlib.readByte("009D7100") & 255);
            while (true)
            {
                Thread.Sleep(threadDelay);
                byte newVal = (byte)(memlib.readByte("009D7100") & 255);
                if(oldVal != newVal)
                {
                    try
                    {
                        Logger.Log("Tower was upgraded");
                        Event.Invoke(this, new EventArgs());
                    } catch (Exception) { }
                }
                oldVal = newVal;
            }
        }
    }
}
