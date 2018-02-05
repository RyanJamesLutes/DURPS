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
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            double timerInterval = 1000 * 5;
            Timer t = new Timer(timerInterval);
            t.Elapsed += T_Elapsed;
            t.Start();
            GC.KeepAlive(t);

            await ReplyAsync("Starting automatic battles...");
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            ResolveBattles();
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
    }
}