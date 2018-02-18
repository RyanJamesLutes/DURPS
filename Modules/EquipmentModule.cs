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
            // TODO: Use FullName when modifiers are added.
            string equippedList = "Head: " + pc.EquippedHead.Name + "\n" +
                                  "Body: " + pc.EquippedBody.Name + "\n" +
                                  "Arms: " + pc.EquippedArms.Name + "\n" +
                                  "Gloves: " + pc.EquippedGloves.Name + "\n" +
                                  "Main Hand: " + pc.EquippedMainHand.Name + "\n" +
                                  "Off-hand: " + pc.EquippedOffHand.Name + "\n" +
                                  "Legs: " + pc.EquippedLegs.Name + "\n" +
                                  "Feet: " + pc.EquippedFeet.Name + "\n";
            await ReplyAsync(equippedList);
        }
        [Command("gear")]
        [Summary("Lists all equipped items.")]
        public async Task Gear()
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            // TODO: Use FullName when modifiers are added.
            string equippedList = "Head: " + pc.EquippedHead.Name + "\n" +
                                  "Body: " + pc.EquippedBody.Name + "\n" +
                                  "Arms: " + pc.EquippedArms.Name + "\n" +
                                  "Gloves: " + pc.EquippedGloves.Name + "\n" +
                                  "Main Hand: " + pc.EquippedMainHand.Name + "\n" +
                                  "Off-hand: " + pc.EquippedOffHand.Name + "\n" +
                                  "Legs: " + pc.EquippedLegs.Name + "\n" +
                                  "Feet: " + pc.EquippedFeet.Name + "\n";
            await ReplyAsync(equippedList);
        }
    }
}