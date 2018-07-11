using Discord.Commands;
using System.Threading.Tasks;

namespace DURPSBot
{
    public class EquipModule : ModuleBase<SocketCommandContext>
    {
        [Command("equip")]
        [Summary("")]
        public async Task EquipAsync([Remainder] [Summary("Inventory index of equipment")] int invIndex)
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            Equipment equipment = pc.InventoryEquipment[invIndex - 1];
            if (pc.InventoryEquipment.Count >= invIndex)
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

        [Command("unequip")]
        [Summary("")]
        public async Task EquipAsync([Remainder] [Summary("Inventory index of equipment")] string userString)
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            Equipment equipment;

            if (userString.ToLower() == "hand" || userString.ToLower() == "hands")
            {
                await ReplyAsync("They're firmly attatched to your wrists. Try \"/unequip mainhand\", \"/unequip offhand\" or \"/unequip gloves\" instead.");
            }
            // TODO: Switch to FullName() when prefixes and suffixes are implemented.
            if (userString.ToLower() == "head" || userString.ToLower() == ("helm") || userString.ToLower() == ("helmet"))
            {
                equipment = pc.EquippedHead;
                pc.Unequip(equipment);
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "body" || userString.ToLower() == "torso" || userString.ToLower() == "chest")
            {
                equipment = pc.EquippedBody;
                pc.Unequip(equipment);
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "arms" || userString.ToLower() == "arm")
            {
                equipment = pc.EquippedArms;
                pc.Unequip(equipment);
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "gloves" || userString.ToLower() == "glove")
            {
                equipment = pc.EquippedGloves;
                pc.Unequip(equipment);
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "mainhand" || userString.ToLower() == "main")
            {
                equipment = pc.EquippedMainHand;
                pc.Unequip(equipment);
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "offhand" || userString.ToLower() == "off")
            {
                equipment = pc.EquippedOffHand;
                pc.Unequip(equipment);
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "legs" || userString.ToLower() == "leg")
            {
                equipment = pc.EquippedLegs;
                pc.Unequip(equipment);
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            else if (userString.ToLower() == "feet" || userString.ToLower() == "foot")
            {
                equipment = pc.EquippedFeet;
                pc.Unequip(equipment);
                await ReplyAsync("Unequipped the " + equipment.Name);
            }
            dm.Save(pc);
        }

        [Command("trash")]
        [Summary("")]
        public async Task TrashAsync([Remainder] [Summary("Inventory index of equipment")] int invIndex)
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            Equipment equipment = pc.InventoryEquipment[invIndex - 1];
            if (pc.InventoryEquipment.Count >= invIndex)
            {
                pc.InventoryEquipment.Remove(equipment);
                dm.Save(pc);
            }
            else
            {
                await ReplyAsync("You don't have that many items in your inventory.");
            }
        }
    }
}