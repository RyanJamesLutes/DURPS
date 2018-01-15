using System;

namespace DURPSBot.Items.Equipment
{
    [Serializable]
    class JestersCap : DURPSBot.Equipment
    {
        public JestersCap()
        {
            Name = "Jester's Cap";
            EquipsToHead = true;
            Price = 10;
            Weight = 1.2;
            DamageResistance = 1;
            Description = "A bright, multicolored cap adorned with bells.";
            TechLevel = 0;
            RequiredClass = "Fool";
            ItemID = GenerateItemID();
        }
    }
}