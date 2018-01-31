using System;

namespace DURPSBot
{
    [Serializable]
    class Equipment : Item
    {
        private bool isWeapon = false;
        private bool isTwoHanded = false;
        private bool isRanged = false;
        private EquipmentPrefix prefix = new EquipmentPrefix();
        private EquipmentSuffix suffix = new EquipmentSuffix();
        private bool equipsToHead = false;
        private bool equipsToBody = false;
        private bool equipsToArms = false;
        private bool equipsToGloves = false;
        private bool equipsToMainHand = false;
        private bool equipsToOffHand = false;
        private bool equipsToLegs = false;
        private bool equipsToFeet = false;
        private string requiredClass = "Any";
        private int requiredLevel = 0;
        private int requiredStrength = 0;
        private int requiredIntelligence = 0;
        private int requiredDexterity = 0;
        private int requiredLuck = 0;
        private int requiredFate = 0;
        private int strength = 0;
        private int intelligence = 0;
        private int dexterity = 0;
        private int luck = 0;
        private int fate = 0;
        private int damage = 0;
        private int parry = 0;
        private string damageType = "";
        private int damageResistance = 0;
        private int accuracy = 0;
        private int rateOfFire = 0;
        private int shots = 0;
        private int reach = 0;
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
        public int RequiredLevel { get => requiredLevel; set => requiredLevel = value; } // Minimum level required to equip item.
        public int RequiredStrength { get => requiredStrength; set => requiredStrength = value; }
        public int RequiredIntelligence { get => requiredIntelligence; set => requiredIntelligence = value; }
        public int RequiredDexterity { get => requiredDexterity; set => requiredDexterity = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Parry { get => parry; set => parry = value; }
        public int DamageResistance { get => damageResistance; set => damageResistance = value; }
        public int Accuracy { get => accuracy; set => accuracy = value; }
        public int RateOfFire { get => rateOfFire; set => rateOfFire = value; }
        public int Shots { get => shots; set => shots = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Luck { get => luck; set => luck = value; }
        public int Fate { get => fate; set => fate = value; }
        public int RequiredLuck { get => requiredLuck; set => requiredLuck = value; }
        public int RequiredFate { get => requiredFate; set => requiredFate = value; }
        public int Reach { get => reach; set => reach = value; }
        public byte TechLevel { get => techLevel; set => techLevel = value; }
        public bool CanParry { get => canParry; set => canParry = value; }
        public string DamageType { get => damageType; set => damageType = value; }

        public int TotalRequiredLevel()
        {
            return RequiredLevel + prefix.RequiredLevel + suffix.RequiredLevel;
        }
        public int TotalRequiredStrength()
        {
            return requiredStrength + prefix.RequiredStrength + suffix.RequiredStrength;
        }
        public int TotalRequiredIntelligence()
        {
            return requiredIntelligence + prefix.RequiredIntelligence + suffix.RequiredIntelligence;
        }
        public int TotalRequiredDexterity()
        {
            return requiredDexterity + prefix.RequiredDexterity + suffix.RequiredDexterity;
        }
        public int TotalRequiredLuck()
        {
            return requiredLuck + prefix.RequiredLuck + suffix.RequiredLuck;
        }
        public int TotalRequiredFate()
        {
            return requiredFate + prefix.RequiredFate + suffix.RequiredFate;
        }
        public int TotalStrength()
        {
            return Strength + prefix.Strength + suffix.Strength;
        }
        public int TotalIntelligence()
        {
            return Intelligence + prefix.Intelligence + suffix.Intelligence;
        }
        public int TotalDexterity()
        {
            return dexterity + prefix.Dexterity + suffix.Dexterity;
        }
        public int TotalLuck()
        {
            return luck + prefix.Luck + suffix.Luck;
        }
        public int TotalFate()
        {
            return fate + prefix.Fate + suffix.Fate;
        }
        public int TotalDamageResistance()
        {
            return DamageResistance + prefix.DamageResistance + suffix.DamageResistance;
        }
        public string FullName()
        {
            return prefix + " " + Name + " " + suffix;
        }
        public double TotaWeight()
        {
            return Weight + (Weight * Prefix.WeightMultiplier - Weight) + (Weight * Suffix.WeightMultiplier - Weight);
        }
        public int TotalPrice()
        {
            return Price + (int)((Price * Prefix.PriceMultiplier - Price) + (Price * Suffix.PriceMultiplier - Price));
        }
        public int TotalDamage()
        {
            return Damage + prefix.Damage + suffix.Damage;
        }
        public virtual void BattleAction(Entity owner, Entity target)
        {
            owner.UnarmedAttack(target);
        }
        public virtual void BattleAction(Entity owner, Entity target, Equipment bodyPart)
        {
            owner.UnarmedAttack(target, bodyPart);
        }
    }
}