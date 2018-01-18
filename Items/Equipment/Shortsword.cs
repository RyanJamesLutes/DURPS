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
            target.CurrentHitPoints -= penetratingDamage;
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
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
    }
}