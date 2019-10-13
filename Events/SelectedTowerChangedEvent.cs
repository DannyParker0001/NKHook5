using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.Events
{
    public class SelectedTowerChangedEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            Tower previousTower = null;
            //Event work
            while (true)
            {
                Thread.Sleep(threadDelay);
                Tower selected = Game.getBTD5().getSelectedTower();
                if (selected != null)
                {
                    if (previousTower == null)
                    {
                        previousTower = selected;
                        continue;
                    }
                }
                else
                {
                    continue;
                }
                if (selected.getMemId() != previousTower.getMemId())
                {
                    try
                    {
                        Event.Invoke(null, new EventArgs());
                    }
                    catch (NullReferenceException) { }
                    //Logger.Log("Tower changed invoked here: " + selected.getMemId());
                }
                previousTower = selected;
            }
        }
    }
}
