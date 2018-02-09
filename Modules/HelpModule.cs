using Discord.Commands;
using System.Threading.Tasks;
using Discord;
namespace DURPSBot
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        [Summary("Displays a list of commands.")]
        public async Task HelpAsync()
        {
            // ReplyAsync is a method on ModuleBase
            var builder = new EmbedBuilder();

            builder.WithTitle("DURPS Commands");
            builder.WithDescription("createcharacter \necho <message> \nequip <inventory #> \nequipment \ngold \nhelp \ninv \nunequip <slot> \nroll <dice notation> \nstats ");

            await Context.Channel.SendMessageAsync("", false, builder);
        }
    }
}
