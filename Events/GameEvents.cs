using Memory;
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
        public static event EventHandler<EventArgs> mapLoadEvent;
        public static event EventHandler<EventArgs> selectedTowerChangedEvent;
        public static event EventHandler<EventArgs> selectedTowerPoppedBloonsChangedEvent;
        internal static void startHandler(Mem memlib)
        {
            UIntPtr moneyAddress = memlib.getCode("BTD5-Win.exe+008844B0,0xC4,0x90");
            UIntPtr healthAddress = memlib.getCode("BTD5-Win.exe+00884274,0x5C,0x8C,0x18,0xC8,0x88");
            
            //Async mapLoadEvent Worker.
            BackgroundWorker mapLoadEventWorker = new BackgroundWorker();
            mapLoadEventWorker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                //Event work
                while (true)
                {
                    Thread.Sleep(50);
                    UIntPtr newMoneyAddress = memlib.getCode("BTD5-Win.exe+008844B0,0xC4,0x90");
                    UIntPtr newHealthAddress = memlib.getCode("BTD5-Win.exe+00884274,0x5C,0x8C,0x18,0xC8,0x88");
                    if(newMoneyAddress != moneyAddress && newHealthAddress != healthAddress)
                    {
                        mapLoadEvent.Invoke(null, new EventArgs());
                    }
                    moneyAddress = newHealthAddress;
                    healthAddress = newHealthAddress;
                }
            };
            mapLoadEventWorker.RunWorkerAsync();

            //Async selectedTowerChanged worker
            BackgroundWorker selectedTowerChangedEventWorker = new BackgroundWorker();
            selectedTowerChangedEventWorker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                //Event work
                Tower previousTower = null;
                while (true)
                {
                    Thread.Sleep(50);
                    Tower selected = Game.getBTD5().getSelectedTower();
                    if(selected != null)
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
                    if(selected.getMemId() != previousTower.getMemId())
                    {
                        try
                        {
                            selectedTowerChangedEvent.Invoke(null, new EventArgs());
                        }
                        catch (NullReferenceException) { }
                        //Logger.Log("Tower changed invoked here: " + selected.getMemId());
                    }
                    previousTower = selected;
                }
            };
            selectedTowerChangedEventWorker.RunWorkerAsync();

            //Async selectedTowerChanged worker
            BackgroundWorker selectedTowerPoppedBloonsChangedEventWorker = new BackgroundWorker();
            selectedTowerPoppedBloonsChangedEventWorker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                //Event work
                int poppedBloons = 0;
                while (true)
                {
                    try
                    {
                        if (Game.getBTD5().getSelectedTower() == null) { continue; }
                        int newPoppedBloons = Game.getBTD5().getSelectedTower().getPoppedBalloons();
                        if (poppedBloons != newPoppedBloons)
                        {
                            try
                            {
                                selectedTowerPoppedBloonsChangedEvent.Invoke(null, new EventArgs());
                            }
                            catch (NullReferenceException) { }
                        }
                        poppedBloons = newPoppedBloons;
                    }
                    catch (NullReferenceException) { }
                }
            };
            selectedTowerPoppedBloonsChangedEventWorker.RunWorkerAsync();
        }
    }
}
    