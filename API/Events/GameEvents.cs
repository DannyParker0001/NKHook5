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
        internal static void startHandler(Mem memlib)
        {
            //Async mapLoadEvent Worker.
            new MapLoadEvent().startAsync();

            //Async selectedTowerChanged worker
            new SelectedTowerChangedEvent().startAsync();

            //Async selectedTowerChanged worker
            new SelectedTowerPoppedBloonsChangedEvent().startAsync();

            //Async tick event
            new GameTickEvent().startAsync();

            //Async money events
            new MoneyChangedEvent().startAsync();
            new MoneyIncreasedEvent().startAsync();
            new MoneyDecreasedEvent().startAsync();

            //Async health events
            new HealthDecreaseEvent().startAsync();

            //Async round events
            new RoundStartEvent().startAsync();

            //Mouse events
            new MouseMoveEvent().startAsync();
            new MouseUpEvent().startAsync();

            //Screen events
            new ScreenChangedEvent().startAsync();
            new ScreenOpenEvent().startAsync();
            new ScreenCloseEvent().startAsync();

            //Tower events
            new TowerPlaceEvent().startAsync();
            new TowerDeleteEvent().startAsync();
        }
    }
}
    