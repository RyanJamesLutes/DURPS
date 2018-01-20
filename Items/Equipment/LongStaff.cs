using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class LongStaff : DURPSBot.Equipment
    {
        // Page 65 of Low-Tech
        public LongStaff()
        {
            Name = "Long Staff";
            IsWeapon = true;
            EquipsToMainHand = true;
            IsTwoHanded = true;
            Price = 15;
            Weight = 4;
            Description = "";
            RequiredStrength = 10;
            Damage = 2;
            Reach = 3;
            Parry = 2;
            TechLevel = 0;
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