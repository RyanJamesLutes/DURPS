using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class Sandals : DURPSBot.Equipment
    {
        // Page 16 Low Tech - Instant Armor
        public Sandals()
        {
            Name = "Sandals";
            EquipsToFeet = true;
            Price = 25;
            Weight = 0.5;
            DamageResistance = 1;
            Description = "";
            TechLevel = 0;
            ItemID = GenerateItemID();
        }
    }
}