using NKHook5.API.Events.Args;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API.Events
{
    public class MouseMoveEvent : NkEvent
    {
        public static event EventHandler<MouseMoveEventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            float mouseX = 0;
            float mouseY = 0;
            while (true)
            {
                Thread.Sleep(threadDelay);
                float newX = memlib.readFloat("BTD5-Win.exe+00884438,0x10,0x20");
                float newY = memlib.readFloat("BTD5-Win.exe+008844B0,0x8,0x24");
                if (newX != mouseX || newY != mouseY)
                {
                    try
                    {
                        Event.Invoke(this, new MouseMoveEventArgs(mouseX, newX, mouseY, newY));
                    }
                    catch (NullReferenceException) { }
                }
                mouseX = newX;
                mouseY = newY;
            }
        }
    }
}
