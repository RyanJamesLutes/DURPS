using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class ClothSleeves : DURPSBot.Equipment
    {
        // Page ?? Basic Set
        public ClothSleeves()
        {
            Name = "Cloth Sleeves";
            EquipsToArms = true;
            Price = 20;
            Weight = 2;
            DamageResistance = 1;
            Description = "";
            TechLevel = 1;
            ItemID = GenerateItemID();
        }
    }
}