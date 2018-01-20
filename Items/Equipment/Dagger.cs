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
        public override void BattleAction(Entity owner, Entity target)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Thrust(owner, target);
                    break;
            }
        }
        public override void BattleAction(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
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
            int penetratingDamage = (owner.BasicThrust() + TotalDamage()) - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
        public void Thrust(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
        {
            Random rng = new Random();
            int penetratingDamage = (owner.BasicThrust() + TotalDamage()) - (target.DamageResistance + bodyPart.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
    }
}