using Discord.Commands;
using System.Threading.Tasks;
using System;

namespace DURPSBot
{
    public class StatsModule : ModuleBase<SocketCommandContext>
    {
        [Command("stats")]
        [Summary("Lists character stats.")]
        public async Task StatsAsync()
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            // TODO: Use FullName and total attributes eventually
            string stats = pc.Name + " the " + pc.CharacterClass + "\n" +
                           "Level " + pc.Level + "\n" +
                           "XP " + pc.Experience + "\n" +
                           "STR: " + pc.Strength + "\n" +
                           "DEX: " + pc.Dexterity + "\n" +
                           "INT: " + pc.Intelligence + "\n" +
                           "Wins: " + pc.Wins + "\n" +
                           "Losses: " + pc.Losses + "\n";

            await ReplyAsync(stats);
        }
    }
}