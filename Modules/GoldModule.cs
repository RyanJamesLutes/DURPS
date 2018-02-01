using Discord.Commands;
using System.Threading.Tasks;
using System;

namespace DURPSBot
{
    public class GoldModule : ModuleBase<SocketCommandContext>
    {
        [Command("gold")]
        [Summary("Lists player character's gold.")]
        public async Task GoldAsync()
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);

            await ReplyAsync("Gold: " + pc.Money);
        }
    }
}