using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class Cloak : DURPSBot.Equipment
    {
        public Cloak()
        {
            Name = "Cloak";
            EquipsToBody = true;
            Price = 60;
            Weight = 2;
            DamageResistance = 0;
            Description = "";
            TechLevel = 0;
            ItemID = GenerateItemID();
        }
    }
}