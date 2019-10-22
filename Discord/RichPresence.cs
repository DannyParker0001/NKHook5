using DiscordRPC;
using NKHook5.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NKHook5.Discord
{
    internal class RichPresence
    {
        internal static DiscordRpcClient client = new DiscordRpcClient("636315850630234139");

        internal static void startRPC()
        {
            client = new DiscordRpcClient("636315850630234139");
            client.Initialize();
            client.SetPresence(new DiscordRPC.RichPresence()
            {
                Details = "NKHook was just hooked",
                State = "Hooked Bloons TD 5"
            });
            Logger.Log("Discord RPC loaded");
            Timer discordTask = new Timer();
            discordTask.Elapsed += (object sen, ElapsedEventArgs arg) =>
              {
                  update();
              };
            discordTask.Interval = 20000;
            discordTask.Start();
        }

        internal static void update()
        {
            client.SetPresence(new DiscordRPC.RichPresence()
            {
                Details = "Round: " + Game.getBTD5().getRound() + " | Money: " + Game.getBTD5().getMoney() + " | Health: " + Game.getBTD5().getHealth(),
                State = "Hooked Bloons TD 5"
            });
        }
    }
}
