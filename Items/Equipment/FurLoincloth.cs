using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class FurLoincloth : DURPSBot.Equipment
    {
        public FurLoincloth()
        {
            Name = "Fur Loincloth";
            EquipsToLegs = true;
            Price = 10;
            Weight = 0;
            DamageResistance = 1;
            Description = "";
            TechLevel = 0;
            ItemID = GenerateItemID();
        }
    }
}