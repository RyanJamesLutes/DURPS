using System;

namespace DURPSBot
{
    [Serializable]
    class EquipmentModifier
    {
        private string name = "";
        /// <summary> Common, Uncommon, Rare, Epic, Legendary</summary>
        ///
        private byte rarity = 0;
        private int requiredLevel = 0;
        private int requiredStrength = 0;
        private int requiredIntelligence = 0;
        private int requiredDexterity = 0;
        private int strength = 0;
        private int intelligence = 0;
        private int dexterity = 0;
        private int luck = 0;
        private int fate = 0;
        private int requiredLuck = 0;
        private int requiredFate = 0;
        private int damage = 0;
        private double weightMultiplier = 0;
        private double priceMultiplier = 0;
        private int damageResistance = 0;
        private int accuracy = 0;
        private int rateOfFire = 0;
        private int shots = 0;

        public string Name { get => name; set => name = value; }
        public byte Rarity { get => rarity; set => rarity = value; }
        public int RequiredLevel { get => requiredLevel; set => requiredLevel = value; }
        public int RequiredStrength { get => requiredStrength; set => requiredStrength = value; }
        public int RequiredIntelligence { get => requiredIntelligence; set => requiredIntelligence = value; }
        public int RequiredDexterity { get => requiredDexterity; set => requiredDexterity = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int RequiredLuck { get => requiredLuck; set => requiredLuck = value; }
        public int RequiredFate { get => requiredFate; set => requiredFate = value; }
        public int Damage { get => damage; set => damage = value; }
        public double WeightMultiplier { get => weightMultiplier; set => weightMultiplier = value; }
        public double PriceMultiplier { get => priceMultiplier; set => priceMultiplier = value; }
        public int DamageResistance { get => damageResistance; set => damageResistance = value; }
        public int Luck { get => luck; set => luck = value; }
        public int Fate { get => fate; set => fate = value; }
        public int Shots { get => shots; set => shots = value; }
        public int RateOfFire { get => rateOfFire; set => rateOfFire = value; }
        public int Accuracy { get => accuracy; set => accuracy = value; }
    }
}