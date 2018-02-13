using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class LeatherPants : DURPSBot.Equipment
    {
        public LeatherPants()
        {
            Name = "Leather Pants";
            EquipsToLegs = true;
            Price = 40;
            Weight = 3;
            DamageResistance = 1;
            Description = "";
            TechLevel = 1;
            ItemID = GenerateItemID();
        }
    }
}