using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class Mace : DURPSBot.Equipment
    {
        // Page 65 of Low-Tech
        public Mace()
        {
            Name = "Mace";
            IsWeapon = true;
            EquipsToMainHand = true;
            Price = 50;
            Weight = 5;
            Description = "An unbalanced, one-handed war club with a large crushing head.";
            RequiredStrength = 12;
            Damage = 3;
            Reach = 1;
            TechLevel = 2;
            ItemID = GenerateItemID();
        }
        public override void BattleAction(Entity owner, Entity target)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Swing(owner, target);
                    break;
            }
        }
        public override void BattleAction(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Swing(owner, target, bodyPart);
                    break;
            }
        }
        public void Swing(Entity owner, Entity target)
        {
            Random rng = new Random();
            int penetratingDamage = (owner.BasicSwing() + TotalDamage()) - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
        public void Swing(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
        {
            Random rng = new Random();
            int penetratingDamage = (owner.BasicSwing() + TotalDamage()) - (target.DamageResistance + bodyPart.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
    }
}