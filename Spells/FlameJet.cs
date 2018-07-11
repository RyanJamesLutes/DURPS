using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot.Spells
{
    class FlameJet : Spell
    {
        // From page 73 of GURPS 4e - Magic
        // TODO: Prerequisites
        public FlameJet()
        {
            Name = "Flame Jet";
            College = "Fire";
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
                // TODO: Dual-handed casting? 
                //       Use TotalDexterity() when modifiers are implemented.
                int diceRoll = new Random().Next(1, 6);

                if (diceRoll > (target.Dexterity - 4))
                {
                    if (power >= 3)
                    {
                        target.StatusEffect.Add(new Status_Effects.OnFire());
                    }
                    target.Health -= power;
                    caster.FatiguePoints -= power;
                }
                return;
            };
        }
    }
}
