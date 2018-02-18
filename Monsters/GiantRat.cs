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
            Health = 13;
            CanDodge = true;
            CanParry = false;
            CanFatigue = true;
            Dodge = 7;
            MaxHitPoints = 9;
            CurrentHitPoints = MaxHitPoints;
            Willpower = 10;
            Perception = 12;
            FatiguePoints = 13;
            Move = 7;
            SizeModifier = -1;
            Speed = 6.5;
            DamageResistance = 1;
            Description = "There’s little to be said about giant rats: they’re as cunning and dextrous as regular rats, but huge, the size of the children they carry off as food.Almost all dungeons have them – especially sewers.They’re fodder for well - equipped adventurers, but every now and then, 20 or 30 of them will get crazy and swarm a party anyway.";
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
            int penetratingDamage = (rng.Next(6) - 1) - (target.DamageResistance + target.EquippedBody.DamageResistance);
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
            int penetratingDamage = (rng.Next(6) - 1) - (target.DamageResistance + bodyPart.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
        public override void Die(PlayerCharacter killer)
        {
            base.Die(killer);
            DataManager dm = new DataManager();
            killer.KilledGiantRats ++;
            dm.Save(killer);
        }
        // TODO: Traits, skills, etc.
    }
}