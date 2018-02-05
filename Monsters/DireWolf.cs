using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot.Monsters
{
    class DireWolf : Monster
    {
        // Page 24 of Dungeon Fantasy 2 - Dungeons
        public DireWolf()
        {
            Name = "Dire Wolf";
            Strength = 16;
            Dexterity = 12;
            Intelligence = 4;
            Health = 12;
            Dodge = 9;
            MaxHitPoints = 16;
            CurrentHitPoints = MaxHitPoints;
            Willpower = 11;
            Perception = 14;
            FatiguePoints = 12;
            CanParry = false;
            CanDodge = true;
            CanFatigue = true;
            Speed = 6.0;
            Move = 9;
            SizeModifier = +1;
            DamageResistance = 2;
            Description = "Dire wolves are huge, strong, fast wolves with thick, wooly coats, keen senses, and a taste for human flesh. Tales of orcs using them as mounts are apocryphal – they’ll eat orcs, too. While one dire wolf might be no challenge for adventurers, they tend to occur in packs of up to 20.";
        }

        public override void BattleAction(Entity target)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Bite(target);
                    break;
            }
        }
        public override void BattleAction(Entity target, Equipment bodyPart)
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
            int penetratingDamage = (rng.Next(6) + 1) - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
        public void Bite(Entity target, Equipment bodyPart)
        {
            Random rng = new Random();
            int penetratingDamage = (rng.Next(6) + 1) - (target.DamageResistance + bodyPart.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
        public override void Die(PlayerCharacter killer)
        {
            DataManager dm = new DataManager();
            killer.KilledDireWolves ++;
            dm.Save(killer);
        }

        // TODO: Traits, skills, etc.
    }
}