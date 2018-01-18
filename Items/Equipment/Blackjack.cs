using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class Blackjack : DURPSBot.Equipment
    {
        // Page 65 of Low-Tech
        public Blackjack()
        {
            Name = "Blackjack";
            IsWeapon = true;
            EquipsToMainHand = true;
            Price = 20;
            Weight = 1;
            Description = "A small, weighted truncheon made of soft leather";
            RequiredStrength = 7;
            Damage = 1;
            Reach = 0;
            TechLevel = 1;
            ItemID = GenerateItemID();
        }
        public void BattleAction(Entity owner, Entity target)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Thrust(owner, target);
                    break;
            }
        }
        public void BattleAction(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Thrust(owner, target, bodyPart);
                    break;
            }
        }
        public void Thrust(Entity owner, Entity target)
        {
            Random rng = new Random();
            int penetratingDamage = (owner.BasicThrust() + Damage) - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHealth -= penetratingDamage;
            return;
        }
        public void Thrust(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
        {
            Random rng = new Random();
            int penetratingDamage = (owner.BasicThrust() + Damage) - (target.DamageResistance + bodyPart.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHealth -= penetratingDamage;
            return;
        }
    }
}