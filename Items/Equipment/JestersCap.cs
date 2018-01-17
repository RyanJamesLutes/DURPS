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
            Weight = 0.5;
            DamageResistance = 0;
            Description = "A bright, multicolored cloth cap adorned with bells.";
            TechLevel = 0;
            RequiredClass = "Fool";
            ItemID = GenerateItemID();
        }
    }
}