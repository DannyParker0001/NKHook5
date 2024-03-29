﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API.Events
{
    public class ScreenChangedEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            //Event work
            int status = 0;
            while (true)
            {
                Thread.Sleep(threadDelay);
                int newStatus = memlib.readByte("BTD5-Win.exe+884290");
                if (newStatus != status)
                {
                    try
                    {
                        Event.Invoke(this, new EventArgs());
                    }
                    catch (NullReferenceException) { }
                }
                status = newStatus;
            }
        }
    }
}
