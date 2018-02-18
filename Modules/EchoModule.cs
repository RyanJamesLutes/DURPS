using Discord.Commands;
using System.Threading.Tasks;

namespace DURPSBot
{
    public class EchoModule : ModuleBase<SocketCommandContext>
    {
        // !echo [message] -> [message]
        [Command("echo")]
        [Summary("Echoes a message.")]
        public async Task EchoAsync([Remainder] [Summary("The text to echo")] string echo)
        {
            if (!Context.Message.Author.IsBot)
            {
                await ReplyAsync(echo);
            }
        }
    }
}