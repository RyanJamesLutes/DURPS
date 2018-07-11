using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot.Spells
{
    class WaterJet : Spell
    {
        // From page 73 of GURPS 4e - Magic
        // TODO: Prerequisites
        public WaterJet()
        {
            Name = "Water Jet";
            College = "Water";
            ManaLevel = 2;
            Description = "Shoot a jet of flame from one fist.";
            UsesFatigue = true;
            MinFatigueCost = 1;
            MaxFatigueCost = 3;
            IsAOE = false;
        }
        public override void Cast(Entity caster, Entity target)
        {
            base.Cast(caster, target);

            int power = new Random().Next(1, 3);

            if (caster.FatiguePoints < power)
            {
                // Spell fails.
                return;
            }
            else
            {
                // TODO: Combat skill penalty
                //       Use TotalDexterity() when modifiers are implemented.
                int diceRoll = new Random().Next(1, 6);

                if (diceRoll > (target.Dexterity - 4))
                {
                    target.Health -= power;
                    caster.FatiguePoints -= power;
                }
                return;
            };
        }
    }
}
