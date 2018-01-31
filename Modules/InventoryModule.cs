using Discord.Commands;
using System.Threading.Tasks;

namespace DURPSBot
{
    public class InventoryModule : ModuleBase<SocketCommandContext>
    {
        // !echo [message] -> [message]
        [Command("inv")]
        [Summary("Lists all items in a player's inventory.")]
        public async Task InventoryAsync()
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            string invList = "";
            foreach (Equipment e in pc.InventoryEquipment)
            {
                // TODO: Change to FullName when prefixes and suffixes are added
                invList += (pc.InventoryEquipment.IndexOf(e) + 1) + ". " + e.Name + "\n";
            }
            await ReplyAsync(invList);
        }
    }
}