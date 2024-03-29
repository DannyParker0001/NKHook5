﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API.Events
{
    public class TowerDeleteEvent : NkEvent
    {
        public static event EventHandler<EventArgs> Event;
        public override void work(object sender, DoWorkEventArgs e)
        {
            base.work(sender, e);

            int towerCount = 0;
            //Event work
            while (true)
            {
                Thread.Sleep(threadDelay);
                int newCount = memlib.readInt("BTD5-Win.exe+008844B0,D8,5AC");
                if (newCount < towerCount)
                {
                    try
                    {
                        Event.Invoke(this, new EventArgs());
                    } catch (Exception) { }
                }
                towerCount = newCount;
            }
        }
    }
}
