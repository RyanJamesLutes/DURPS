using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class Quarterstaff : DURPSBot.Equipment
    {
        // Page 273 of Basic Set
        public Quarterstaff()
        {
            Name = "Quarterstaff";
            IsWeapon = true;
            EquipsToMainHand = true;
            Price = 10;
            Weight = 4;
            Description = "";
            RequiredStrength = 7;
            CanParry = true;
            Parry = 2;
            Damage = 2;
            Reach = 2;
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