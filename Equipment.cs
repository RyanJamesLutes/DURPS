using System;

namespace DURPSBot
{
    [Serializable]
    class Equipment : Item
    {
        private bool isWeapon = false;
        private bool isTwoHanded = false;
        private bool isRanged = false;
        private EquipmentPrefix prefix;
        private EquipmentSuffix suffix;
        private bool equipsToHead = false;
        private bool equipsToBody = false;
        private bool equipsToArms = false;
        private bool equipsToGloves = false;
        private bool equipsToMainHand = false;
        private bool equipsToOffHand = false;
        private bool equipsToLegs = false;
        private bool equipsToFeet = false;
        private string requiredClass = "Any";
        private long requiredLevel = 0;
        private long requiredStrength = 0;
        private long requiredIntelligence = 0;
        private long requiredDexterity = 0;
        private long requiredLuck = 0;
        private long requiredFate = 0;
        private long strength = 0;
        private long intelligence = 0;
        private long dexterity = 0;
        private long luck = 0;
        private long fate = 0;
        private long damage = 0;
        private long parry = 0;
        private long damageResistance = 0;
        private long accuracy = 0;
        private long rateOfFire = 0;
        private long shots = 0;
        private long reach = 0;
        private byte techLevel = 0;
        private bool canParry = false;

        public bool IsWeapon { get => isWeapon; set => isWeapon = value; }
        public bool IsTwoHanded { get => isTwoHanded; set => isTwoHanded = value; }
        public bool IsRanged { get => isRanged; set => isRanged = value; }
        internal EquipmentPrefix Prefix { get => prefix; set => prefix = value; }
        internal EquipmentSuffix Suffix { get => suffix; set => suffix = value; }
        public bool EquipsToHead { get => equipsToHead; set => equipsToHead = value; }
        public bool EquipsToBody { get => equipsToBody; set => equipsToBody = value; }
        public bool EquipsToArms { get => equipsToArms; set => equipsToArms = value; }
        public bool EquipsToGloves { get => equipsToGloves; set => equipsToGloves = value; }
        public bool EquipsToMainHand { get => equipsToMainHand; set => equipsToMainHand = value; }
        public bool EquipsToOffHand { get => equipsToOffHand; set => equipsToOffHand = value; }
        public bool EquipsToLegs { get => equipsToLegs; set => equipsToLegs = value; }
        public bool EquipsToFeet { get => equipsToFeet; set => equipsToFeet = value; }
        public string RequiredClass { get => requiredClass; set => requiredClass = value; }
        public long RequiredLevel { get => requiredLevel; set => requiredLevel = value; } // Minimum level required to equip item.
        public long RequiredStrength { get => requiredStrength; set => requiredStrength = value; }
        public long RequiredIntelligence { get => requiredIntelligence; set => requiredIntelligence = value; }
        public long RequiredDexterity { get => requiredDexterity; set => requiredDexterity = value; }
        public long Strength { get => strength; set => strength = value; }
        public long Intelligence { get => intelligence; set => intelligence = value; }
        public long Dexterity { get => dexterity; set => dexterity = value; }
        public long Parry { get => parry; set => parry = value; }
        public long DamageResistance { get => damageResistance; set => damageResistance = value; }
        public long Accuracy { get => accuracy; set => accuracy = value; }
        public long RateOfFire { get => rateOfFire; set => rateOfFire = value; }
        public long Shots { get => shots; set => shots = value; }
        public long Damage { get => Damage; set => Damage = value; }
        public long Luck { get => luck; set => luck = value; }
        public long Fate { get => fate; set => fate = value; }
        public long RequiredLuck { get => requiredLuck; set => requiredLuck = value; }
        public long RequiredFate { get => requiredFate; set => requiredFate = value; }
        public long Reach { get => reach; set => reach = value; }
        public byte TechLevel { get => techLevel; set => techLevel = value; }
        public bool CanParry { get => canParry; set => canParry = value; }

        public long TotalRequiredLevel()
        {
            return RequiredLevel + prefix.RequiredLevel + suffix.RequiredLevel;
        }
        public long TotalRequiredStrength()
        {
            return requiredStrength + prefix.RequiredStrength + suffix.RequiredStrength;
        }
        public long TotalRequiredIntelligence()
        {
            return requiredIntelligence + prefix.RequiredIntelligence + suffix.RequiredIntelligence;
        }
        public long TotalRequiredDexterity()
        {
            return requiredDexterity + prefix.RequiredDexterity + suffix.RequiredDexterity;
        }
        public long TotalStrength()
        {
            return Strength + prefix.Strength + suffix.Strength;
        }
        public long TotalIntelligence()
        {
            return Intelligence + prefix.Intelligence + suffix.Intelligence;
        }
        public long TotalDexterity()
        {
            return dexterity + prefix.Dexterity + suffix.Dexterity;
        }
        public long TotalDamageResistance()
        {
            return DamageResistance + prefix.DamageResistance + suffix.DamageResistance;
        }
        public string FullName()
        {
            return prefix + " " + Name + " " + suffix;
        }
        public decimal TotaWeight()
        {
            return Weight + (Weight * Prefix.WeightMultiplier - Weight) + (Weight * Suffix.WeightMultiplier - Weight);
        }
        public long TotalPrice()
        {
            return Price + (Price * (long)Math.Round(Price * Prefix.PriceMultiplier) - Price) + (Price * (long)Math.Round(Price * Suffix.PriceMultiplier) - Price);
        }
        public long TotalDamage()
        {
            return Damage + prefix.Damage + suffix.Damage;
        }
    }
}