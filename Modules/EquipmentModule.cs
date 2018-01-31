using Discord.Commands;
using System.Threading.Tasks;
using System;

namespace DURPSBot
{
    public class EquipmentModule : ModuleBase<SocketCommandContext>
    {
        [Command("equipment")]
        [Summary("Lists all equipped items.")]
        public async Task EquipmentAsync()
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            string equippedList = "";
            foreach (Equipment e in pc.AllEquipped())
            {
                // TODO: Change to FullName when prefixes and suffixes are added
                equippedList = String.Concat(equippedList, (pc.AllEquipped().IndexOf(e) + 1) + ". " + e.Name + "\n");
            }
            await ReplyAsync(equippedList);
        }
    }
}