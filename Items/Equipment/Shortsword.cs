using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class Shortsword : DURPSBot.Equipment
    {
        // Page 69 of Low-Tech
        public Shortsword()
        {
            Name = "Shortsword";
            IsWeapon = true;
            EquipsToMainHand = true;
            Price = 400;
            Weight = 2;
            Description = "";
            RequiredStrength = 8;
            Damage = 0;
            Reach = 1;
            TechLevel = 1;
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