using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class Robes : DURPSBot.Equipment
    {
        public Robes()
        {
            Name = "Robes";
            EquipsToBody = true;
            Price = 120;
            Weight = 2;
            DamageResistance = 0;
            Description = "";
            TechLevel = 0;
            ItemID = GenerateItemID();
        }
    }
}