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
            
            //TODO: embed DURPS icon into embeds without hardcoding the avatar URL
            builder.WithThumbnailUrl("https://cdn.discordapp.com/avatars/408107010966421515/46b627f6e3ba26ca68b4af2ffe40bd44.webp?size=128");

            await Context.Channel.SendMessageAsync("", false, builder);
        }
    }
}
