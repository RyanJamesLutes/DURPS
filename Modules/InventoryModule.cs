using Discord.Commands;
using System.Threading.Tasks;
using System;

namespace DURPSBot
{
    public class InventoryModule : ModuleBase<SocketCommandContext>
    {
        [Command("inv")]
        [Summary("Lists all items in a player's inventory.")]
        public async Task InvAsync()
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            string invList = "";
            if (pc.InventoryEquipment.Count > 0)
            {
                foreach (Equipment e in pc.InventoryEquipment)
                {
                    // TODO: Change to FullName when prefixes and suffixes are added
                    invList = String.Concat(invList, (pc.InventoryEquipment.IndexOf(e) + 1) + ". " + e.Name + "\n");
                }
                // TODO: List gold.
                await ReplyAsync(invList);
            }
            else
            {
                await ReplyAsync("Your inventory is empty!");
            }
        }

        [Command("inventory")]
        [Summary("Lists all items in a player's inventory.")]
        public async Task InventoryAsync()
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            string invList = "";
            if (pc.InventoryEquipment.Count > 0)
            {
                foreach (Equipment e in pc.InventoryEquipment)
                {
                    // TODO: Change to FullName when prefixes and suffixes are added
                    invList = String.Concat(invList, (pc.InventoryEquipment.IndexOf(e) + 1) + ". " + e.Name + "\n");
                }
                await ReplyAsync(invList);
            }
            else
            {
                await ReplyAsync("Your inventory is empty!");
            }
        }
    }
}