using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class Axe : DURPSBot.Equipment
    {
        // Page 65 of Low-Tech
        public Axe()
        {
            Name = "Axe";
            IsWeapon = true;
            EquipsToMainHand = true;
            Price = 50;
            Weight = 4;
            Description = "A wedge-shaped blade on a wooden handle, not balanced for throwing.";
            RequiredStrength = 11;
            Damage = 2;
            Reach = 1;
            TechLevel = 0;
            ItemID = GenerateItemID();
        }
        public void BattleAction(Entity owner, Entity target)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Swing(owner, target);
                    break;
            }
        }
        public void BattleAction(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
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
            int penetratingDamage = (owner.BasicSwing() + owner.TotalDamage()) - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHealth -= penetratingDamage;
            return;
        }
        public void Swing(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
        {
            Random rng = new Random();
            int penetratingDamage = (owner.BasicSwing() + owner.TotalDamage()) - (target.DamageResistance + bodyPart.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHealth -= penetratingDamage;
            return;
        }
    }
}