using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class BrassKnuckles : DURPSBot.Equipment
    {
        // Page 65 of Low-Tech
        public BrassKnuckles()
        {
            Name = "Brass Knuckles";
            IsWeapon = true;
            IsTwoHanded = true;
            EquipsToMainHand = true;
            Price = 10;
            Weight = 0.25;
            Description = "A metal guard worn over the knuckles.";
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