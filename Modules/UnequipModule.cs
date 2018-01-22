using Discord.Commands;
using System.Threading.Tasks;

namespace DURPSBot
{
    public class UnequipModule : ModuleBase<SocketCommandContext>
    {
        [Command("unequip")]
        [Summary("Displays a list of commands.")]
        public async Task EquipAsync([Remainder] [Summary("Inventory index of equipment")] string userString)
        {
            string commandAuthor = Context.Message.Author.Discriminator;
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(commandAuthor);
            Equipment equipment;

            if (userString.ToLower() == "hand" || userString.ToLower() == "hands")
            {
                await ReplyAsync("They're firmly attatched to your wrists. Try \"/unequip mainhand\", \"/unequip offhand\" or \"/unequip gloves\" instead.");
            }
            // TODO: Switch to FullName() when prefixes and suffixes are implemented.
            if (userString.ToLower() == "head" || userString.ToLower() == ("helm") || userString.ToLower() == ("helmet"))
            {
                equipment = pc.EquippedHead;
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "body" || userString.ToLower() == "torso" || userString.ToLower() == "chest")
            {
                equipment = pc.EquippedBody;
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "arms" || userString.ToLower() == "arm")
            {
                equipment = pc.EquippedArms;
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "gloves" || userString.ToLower() == "glove")
            {
                equipment = pc.EquippedGloves;
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "mainhand" || userString.ToLower() == "main")
            {
                equipment = pc.EquippedMainHand;
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "offhand" || userString.ToLower() == "off")
            {
                equipment = pc.EquippedOffHand;
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "legs" || userString.ToLower() == "leg")
            {
                equipment = pc.EquippedLegs;
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "feet" || userString.ToLower() == "foot")
            {
                equipment = pc.EquippedFeet;
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            dm.Save(pc);
        }
    }
}