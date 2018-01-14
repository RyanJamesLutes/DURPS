using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class LeatherGloves : DURPSBot.Equipment
    {
        public LeatherGloves()
        {
            Name = "Leather Gloves";
            EquipsToFeet = true;
            Price = 15;
            Weight = 0.5;
            DamageResistance = 0;
            Description = "";
            TechLevel = 1;
            ItemID = GenerateItemID();
        }
    }
}