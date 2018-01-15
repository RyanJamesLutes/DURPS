namespace DURPSBot
{
    class EquipmentModifier
    {
        private string name;
        /// <summary> Common, Uncommon, Rare, Epic, Legendary</summary>
        ///
        private byte rarity;
        private long requiredLevel = 0;
        private long requiredStrength = 0;
        private long requiredIntelligence = 0;
        private long requiredDexterity = 0;
        private long strength = 0;
        private long intelligence = 0;
        private long dexterity = 0;
        private long luck = 0;
        private long fate = 0;
        private long requiredLuck = 0;
        private long requiredFate = 0;
        private long damage = 0;
        private decimal weightMultiplier = 0;
        private decimal priceMultiplier = 0;
        private long damageResistance = 0;
        private long accuracy = 0;
        private long rateOfFire = 0;
        private long shots = 0;

        public string Name { get => name; set => name = value; }
        public byte Rarity { get => rarity; set => rarity = value; }
        public long RequiredLevel { get => requiredLevel; set => requiredLevel = value; }
        public long RequiredStrength { get => requiredStrength; set => requiredStrength = value; }
        public long RequiredIntelligence { get => requiredIntelligence; set => requiredIntelligence = value; }
        public long RequiredDexterity { get => requiredDexterity; set => requiredDexterity = value; }
        public long Strength { get => strength; set => strength = value; }
        public long Intelligence { get => intelligence; set => intelligence = value; }
        public long Dexterity { get => dexterity; set => dexterity = value; }
        public long Damage { get => damage; set => damage = value; }
        public decimal WeightMultiplier { get => weightMultiplier; set => weightMultiplier = value; }
        public decimal PriceMultiplier { get => priceMultiplier; set => priceMultiplier = value; }
        public long DamageResistance { get => damageResistance; set => damageResistance = value; }
        public long Luck { get => luck; set => luck = value; }
        public long Fate { get => fate; set => fate = value; }
        public long Shots { get => shots; set => shots = value; }
        public long RateOfFire { get => rateOfFire; set => rateOfFire = value; }
        public long Accuracy { get => accuracy; set => accuracy = value; }
        public long RequiredLuck { get => requiredLuck; set => requiredLuck = value; }
        public long RequiredFate { get => requiredFate; set => requiredFate = value; }
    }
}