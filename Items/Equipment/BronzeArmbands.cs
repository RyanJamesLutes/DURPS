using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class BronzeArmbands : DURPSBot.Equipment
    {
        // Page 283 Basic Set
        public BronzeArmbands()
        {
            Name = "Bronze Armbands";
            EquipsToArms = true;
            Price = 180;
            Weight = 9;
            DamageResistance = 3;
            Description = "";
            TechLevel = 1;
            ItemID = GenerateItemID();
        }
    }
}