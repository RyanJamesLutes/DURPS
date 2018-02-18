using System;

namespace DURPSBot
{
    class Monster : Entity
    {
        public override void Die(PlayerCharacter killer)
        {
            DataManager dm = new DataManager();
            Random rng = new Random();
            // TODO: Replace with total values when modifiers are implemented.
            long drop = (Money + Strength + Dexterity + Intelligence + rng.Next(killer.Luck)) - 25;
            if (drop < 0) { drop = 0; }
            killer.Money += drop;
            dm.Save(killer);
        }
    }
}
