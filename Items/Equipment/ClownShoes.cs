using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class ClownShoes : DURPSBot.Equipment
    {
        //Based on Shoes from page 284 - Basic Set
        public ClownShoes()
        {
            Name = "Clown Shoes";
            EquipsToFeet = true;
            Price = 40;
            Weight = 2;
            DamageResistance = 1;
            Description = "";
            TechLevel = 1;
            ItemID = GenerateItemID();
        }
    }
}