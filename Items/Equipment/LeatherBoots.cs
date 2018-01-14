using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class LeatherBoots : DURPSBot.Equipment
    {
        public LeatherBoots()
        {
            Name = "Leather Boots";
            EquipsToFeet = true;
            Price = 80;
            Weight = 3;
            DamageResistance = 2;
            Description = "";
            TechLevel = 1;
            ItemID = GenerateItemID();
        }
    }
}