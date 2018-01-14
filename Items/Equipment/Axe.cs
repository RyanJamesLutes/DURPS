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