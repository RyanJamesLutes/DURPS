using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class Dagger : DURPSBot.Equipment
    {
        // Page 67 of Low-Tech
        public Dagger()
        {
            Name = "Dagger";
            IsWeapon = true;
            EquipsToMainHand = true;
            Price = 20;
            Weight = 0.25;
            Description = "A short, pointed knife.";
            RequiredStrength = 5;
            Damage = -2;
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
            int defactoDamage = (owner.BasicThrust() + Damage) - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (defactoDamage < 0)
            {
                defactoDamage = 0;
            }
            target.CurrentHealth -= defactoDamage;
            return;
        }
        public void Thrust(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
        {
            Random rng = new Random();
            int defactoDamage = (owner.BasicThrust() + Damage) - (target.DamageResistance + bodyPart.DamageResistance);
            if (defactoDamage < 0)
            {
                defactoDamage = 0;
            }
            target.CurrentHealth -= defactoDamage;
            return;
        }
    }
}