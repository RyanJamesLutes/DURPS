using Discord.Commands;
using System.Threading.Tasks;

namespace DURPSBot
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        [Summary("Displays a list of commands.")]
        public async Task HelpAsync()
        {
            // ReplyAsync is a method on ModuleBase
            await ReplyAsync("createcharacter \necho <message> \nequip <inventory #>\nhelp \ninv \nunequip <slot> \nroll <dice notation>");
        }
    }
}