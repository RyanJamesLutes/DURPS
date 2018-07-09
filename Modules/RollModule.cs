using Discord.Commands;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DURPSBot
{
public class RollModule : ModuleBase<SocketCommandContext>
    {
        [Command("r")]
        [Summary("Rolls dice.")]
        public async Task RollAsync([Remainder] [Summary("Dice roll notation")] string input)
        {
            int diceQuantity = Int32.Parse(Regex.Match(input, @"\d+(?=d)").Value);
            string modifierOperator = Regex.Match(input, @"\+|\-|\*|\/").Value;
            int modifierValue;
            int diceMaximum;
 
            if (modifierOperator != "")
            {
                diceMaximum = Int32.Parse(Regex.Match(input, @"\d+(?=(\+|\-|\*|\/))").Value); //match pattern given a modifier operator's presence
            }
            else
            {
                diceMaximum = Int32.Parse(Regex.Match(input, @"\d+$").Value); //match pattern without modifier
            }
 
            Random rng = new Random();
            List<int> diceRolls = new List<int>();
            int rollTotal = 0;
 
            for (int i = 0; i < diceQuantity; i++)
            {
                int r = rng.Next(1, diceMaximum);
                diceRolls.Add(r);
                rollTotal += r;
            }
 
            string output = string.Join(", ", diceRolls.ToArray());
 
            switch (modifierOperator)
            {
                case "":
                await ReplyAsync("🎲 `" + output + " Total: " + rollTotal + "`");
                break;
 
                case "+":
                modifierValue = Int32.Parse(Regex.Match(input, @"\d+$").Value);
                output += " " + modifierOperator + " " + modifierValue;
                rollTotal += modifierValue;
                await ReplyAsync("🎲 `" + output + " = " + rollTotal + "`");
                break;
 
                case "-":
                modifierValue = Int32.Parse(Regex.Match(input, @"\d+$").Value);
                output += " " + modifierOperator + " " + modifierValue;
                rollTotal -= modifierValue;
                await ReplyAsync("🎲 `" + output + " = " + rollTotal + "`");
                break;
 
                case "*":
                modifierValue = Int32.Parse(Regex.Match(input, @"\d+$").Value);
                output += " " + modifierOperator + " " + modifierValue;
                rollTotal *= modifierValue;
                await ReplyAsync("🎲 `" + output + " = " + rollTotal + "`");
                break;
 
                case "/":
                modifierValue = Int32.Parse(Regex.Match(input, @"\d+$").Value);
                output += " " + modifierOperator + " " + modifierValue;
                rollTotal /= modifierValue;
                await ReplyAsync("🎲 `" + output + " = " + rollTotal + "`");
                break;
            }
        }
    }
}
