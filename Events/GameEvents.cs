using Memory;
using NKHook5.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKHook5
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

            //Async money changed event thing
            new MoneyChangedEvent().startAsync();
        }
    }
}
    