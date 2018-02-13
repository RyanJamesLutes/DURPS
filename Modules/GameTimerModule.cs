using Discord.Commands;
using System.Threading.Tasks;
using System;
using System.Timers;
using Discord;

namespace DURPSBot
{
    public class GameTimerModule : ModuleBase<SocketCommandContext>
    {
        [Command("start")]
        [RequireOwner]
        public async Task GameTimerAsync()
        {
            double timerInterval = 1000 * 60 * 30;
            Timer t = new Timer(timerInterval);
            t.Elapsed += T_Elapsed;
            t.Start();
            GC.KeepAlive(t);
            await ReplyAsync("Starting automatic battles...");
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            DataManager dm = new DataManager();
            ResolveBattles();
            Context.Client.SetGameAsync("Online: " + OnlinePlayers().ToString(), "", 0);
        }

        private void ResolveBattles()
        {
            DataManager dm = new DataManager();
            ulong[] playerIDs = dm.AllPlayerIDs();
            foreach (ulong id in playerIDs)
            {
                var user = Context.Client.GetUser(id);
                if (!(user.Status == UserStatus.Offline))
                {
                    Battle battle = new Battle(dm.Load(id));
                    battle.Fight();
                }
            }
        }

        private int OnlinePlayers()
        {
            int i = 0;
            DataManager dm = new DataManager();
            ulong[] playerIDs = dm.AllPlayerIDs();
            foreach (ulong id in playerIDs)
            {
                var user = Context.Client.GetUser(id);
                if (!(user.Status == UserStatus.Offline))
                {
                    i++;
                }
            }
            return i;
        }
    }
}