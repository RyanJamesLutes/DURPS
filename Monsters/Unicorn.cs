using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot.Monsters
{
    class Unicorn : Monster
    {
        // Page 49 of Fantasy
        public Unicorn()
        {
            Name = "Unicorn";
            Strength = 18;
            Dexterity = 13;
            Intelligence = 4;
            Health = 11;
            CanDodge = true;
            CanParry = true;
            CanFatigue = true;
            Dodge = 10;
            MaxHitPoints = 16;
            CurrentHitPoints = MaxHitPoints;
            Willpower = 12;
            Perception = 12;
            Speed = 6.0;
            SizeModifier = +1;
            Description = "";
        }

        public override void BattleAction(Entity target)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    UnarmedAttack(target);
                    break;
            }
        }
        public override void BattleAction(Entity target, Equipment bodyPart)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    UnarmedAttack(target, bodyPart);
                    break;
            }
        }
        public override void Die(PlayerCharacter killer)
        {
            DataManager dm = new DataManager();
            killer.KilledUnicorns ++;
            dm.Save(killer);
        }

        // TODO: Traits, skills, etc.
    }
}