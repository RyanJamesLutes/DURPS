using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot.Monsters
{
    class Zombie : Monster
    {
        // "Slow Zombie" from Page 13 of Monster Hunters 3 - The Enemy
        public Zombie()
        {
            Name = "Zombie";
            Strength = 15;
            Dexterity = 9;
            Intelligence = 3;
            Health = 10;
            CanDodge = false;
            CanParry = false;
            CanFatigue = false;
            MaxHitPoints = 15;
            CurrentHitPoints = MaxHitPoints;
            Willpower = 12;
            Perception = 8;
            Speed = 4.75;
            Description = "";
            DamageResistance = 1;
        }

        public void BattleAction(Entity target)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Bite(target);
                    break;
            }
        }
        public void BattleAction(Entity target, Equipment bodyPart)
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
            // +2 is from all-out attack, never defends.
            int penetratingDamage = (rng.Next(6) + 1 + 2) - (target.DamageResistance + target.EquippedBody.DamageResistance);
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
            // +2 is from all-out attack, never defends.
            int penetratingDamage = (rng.Next(6) + 1 + 2) - (target.DamageResistance + bodyPart.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
        public override void Die(PlayerCharacter killer)
        {
            killer.KilledZombies += 1;
            return;
        }

        // TODO: Traits, skills, etc.
    }
}