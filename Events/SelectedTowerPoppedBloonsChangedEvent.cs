using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.Events
{
    public class SelectedTowerPoppedBloonsChangedEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            //Event work
            int poppedBloons = 0;
            while (true)
            {
                Thread.Sleep(threadDelay);
                try
                {
                    if (Game.getBTD5().getSelectedTower() == null) { continue; }
                    int newPoppedBloons = Game.getBTD5().getSelectedTower().getPoppedBalloons();
                    if (poppedBloons != newPoppedBloons)
                    {
                        try
                        {
                            Event.Invoke(null, new EventArgs());
                        }
                        catch (NullReferenceException) { }
                    }
                    poppedBloons = newPoppedBloons;
                }
                catch (NullReferenceException) { }
            }
        }
    }
}
