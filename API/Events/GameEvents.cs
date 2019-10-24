using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5.API.Events
{
    public class GameEvents
    {
        internal static void startHandler()
        {
            //Start all the event listeners. Sleep 1 millisecond to spread processor usage.


            //Async mapLoadEvent Worker.
            new MapLoadEvent().startAsync();
            Thread.Sleep(1);

            //Async selectedTowerChanged worker
            new SelectedTowerChangedEvent().startAsync();
            Thread.Sleep(1);

            //Async selectedTowerChanged worker
            new SelectedTowerPoppedBloonsChangedEvent().startAsync();
            Thread.Sleep(1);

            //General events
            new GameTickEvent().startAsync();
            new GameCloseEvent().startAsync();
            Thread.Sleep(1);

            //Async money events
            new MoneyChangedEvent().startAsync();
            new MoneyIncreasedEvent().startAsync();
            new MoneyDecreasedEvent().startAsync();
            Thread.Sleep(1);

            //Async health events
            new HealthDecreaseEvent().startAsync();
            Thread.Sleep(1);

            //Async round events
            new RoundStartEvent().startAsync();
            Thread.Sleep(1);

            //Mouse events
            new MouseMoveEvent().startAsync();
            new MouseUpEvent().startAsync();
            Thread.Sleep(1);

            //Screen events
            new ScreenChangedEvent().startAsync();
            new ScreenOpenEvent().startAsync();
            new ScreenCloseEvent().startAsync();
            Thread.Sleep(1);

            //Tower events
            new TowerPlaceEvent().startAsync();
            new TowerDeleteEvent().startAsync();
            Thread.Sleep(1);

            //Fast forward events
            new FastForwardDisabledEvent().startAsync();
            new FastForwardEnabledEvent().startAsync();
            new FastForwardToggledEvent().startAsync();
            Thread.Sleep(1);
        }
    }
}
    