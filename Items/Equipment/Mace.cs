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
        public void Action(Entity owner, Entity target)
        {
            Random rng = new Random();
            switch (rng.Next(1, 1))
            {
                case 1:
                    Swing(owner, target);
                    break;
            }
        }
        public void Action(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
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
            long defactoDamage = (owner.BasicSwing() + owner.TotalDamage()) - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (defactoDamage < 0)
            {
                defactoDamage = 0;
            }
            target.CurrentHealth -= defactoDamage;
            return;
        }
        public void Swing(Entity owner, Entity target, DURPSBot.Equipment bodyPart)
        {
            Random rng = new Random();
            long defactoDamage = (owner.BasicSwing() + owner.TotalDamage()) - (target.DamageResistance + bodyPart.DamageResistance);
            if (defactoDamage < 0)
            {
                defactoDamage = 0;
            }
            target.CurrentHealth -= defactoDamage;
            return;
        }
    }
}