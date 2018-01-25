using Discord.Commands;
using System.Threading.Tasks;

namespace DURPSBot
{
    public class EquipModule : ModuleBase<SocketCommandContext>
    {
        [Command("equip")]
        [Summary("Displays a list of commands.")]
        public async Task EquipAsync([Remainder] [Summary("Inventory index of equipment")] int invIndex)
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Discriminator);
            Equipment equipment = pc.Inventory[invIndex + 1];
            if (pc.Inventory.Count >= invIndex + 1)
            {
                if (pc.MeetsRequirements(equipment))
                {
                    pc.Equip(equipment);
                    dm.Save(pc);

                    // TODO: change to FullName() when prefixes and suffixes are implemented.
                    await ReplyAsync("Equipped the " + equipment.Name);
                }
                else
                {
                    await ReplyAsync("You do not meet the minimum requirements to equip this.");
                }
            }
            else
            {
                await ReplyAsync("You don't have that many items in your inventory.");
            }
        }
    }
}