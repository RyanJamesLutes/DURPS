using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class LeatherJacket : DURPSBot.Equipment
    {
        public LeatherJacket()
        {
            Name = "Leather Jacket";
            EquipsToBody = true;
            Price = 50;
            Weight = 4;
            DamageResistance = 1;
            Description = "";
            TechLevel = 1;
            ItemID = GenerateItemID();
        }
    }
}