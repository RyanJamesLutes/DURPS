using Discord.Commands;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace DURPSBot
{
    public class RollModule : ModuleBase<SocketCommandContext>
    {
        // !roll 3d6 -> 2, 5, 1
        [Command("roll")]
        [Summary("Rolls dice.")]
        public async Task RollAsync([Remainder] [Summary("Dice roll notation")] string diceNotation)
        {
            int numDice = Int32.Parse(diceNotation.Substring(0, diceNotation.IndexOf('d')));
            int numSides = Int32.Parse(diceNotation.Substring((diceNotation.IndexOf('d') + 1)));
            int[] results = new Dice().Roll(numDice, numSides);

            await ReplyAsync("🎲 ```" + results.Select(a => a.ToString()).Aggregate((i, j) => i + ", " + j) + " Total: " + results.Sum() + "```");
        }
    }
}