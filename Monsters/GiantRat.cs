using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot.Monsters
{
    class GiantRat : Monster
    {
        // Page 24 of Dungeon Fantasy 2 - Dungeons
        public GiantRat()
        {
            Name = "Giant Rat";
            Strength = 9;
            Dexterity = 13;
            Intelligence = 5;
            CurrentHealth = 9;
            MaxHealth = 9;
        }

        public void Action(Entity target)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Bite(target);
                    break;
            }
        }
        public void Action(Entity target, Equipment bodyPart)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Bite(target, bodyPart);
                    break;
            }
        }
        public void Bite(Entity target)
        {
            Random rng = new Random();
            long defactoDamage = (rng.Next(6) - 1) - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (defactoDamage < 0)
            {
                defactoDamage = 0;
            }
            target.CurrentHealth -= defactoDamage;
            return;
        }
        public void Bite(Entity target, Equipment bodyPart)
        {
            Random rng = new Random();
            long defactoDamage = (rng.Next(6) - 1) - (target.DamageResistance + bodyPart.DamageResistance);
            if (defactoDamage < 0)
            {
                defactoDamage = 0;
            }
            target.CurrentHealth -= defactoDamage;
            return;
        }
    }
}