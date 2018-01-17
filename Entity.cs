using System;
using System.Collections.Generic;
using System.Linq;

namespace DURPSBot
{
    internal class Entity
    {
        private EntityPrefix prefix;
        private string name;
        private EntitySuffix suffix;
        private int level;
        private long experience;
        private int currentHealth;
        private int maxHealth;
        private int strength;
        private int intelligence;
        private int dexterity;
        private int luck;
        private int fate;
        private int damageResistance;
        private List<Trait> traits;
        private List<StatusEffect> statusEffect;
        private Equipment equippedHead = new Items.Equipment.Empty();
        private Equipment equippedBody = new Items.Equipment.Empty();
        private Equipment equippedArms = new Items.Equipment.Empty();
        private Equipment equippedGloves = new Items.Equipment.Empty();
        private Equipment equippedMainHand = new Items.Equipment.Empty();
        private Equipment equippedOffHand = new Items.Equipment.Empty();
        private Equipment equippedLegs = new Items.Equipment.Empty();
        private Equipment equippedFeet = new Items.Equipment.Empty();
        private List<Equipment> allEquipment;
        private List<Item> inventory;
        private long money;

        // Base attributes and modifiers
        internal EntityPrefix Prefix { get => prefix; set => prefix = value; }
        public string Name { get => name; set => name = value; }
        internal EntitySuffix Suffix { get => suffix; set => suffix = value; }
        public int Level { get => level; set => level = value; }
        public long Experience { get => experience; set => experience = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Luck { get => luck; set => luck = value; }
        public int Fate { get => fate; set => fate = value; }
        public int DamageResistance { get => damageResistance; set => damageResistance = value; }
        internal List<Trait> Traits { get => traits; set => traits = value; }
        internal List<StatusEffect> StatusEffect { get => statusEffect; set => statusEffect = value; }

        // Inventory and equipment
        public Equipment EquippedHead { get => equippedHead; set => equippedHead = value; }
        public Equipment EquippedBody { get => equippedBody; set => equippedBody = value; }
        public Equipment EquippedArms { get => equippedArms; set => equippedArms = value; }
        public Equipment EquippedGloves { get => equippedGloves; set => equippedGloves = value; }
        public Equipment EquippedMainHand { get => equippedMainHand; set => equippedMainHand = value; }
        public Equipment EquippedOffHand { get => equippedOffHand; set => equippedOffHand = value; }
        public Equipment EquippedLegs { get => equippedLegs; set => equippedLegs = value; }
        public Equipment EquippedFeet { get => equippedFeet; set => equippedFeet = value; }
        public List<Item> Inventory { get => inventory; set => inventory = value; }
        public long Money { get => money; set => money = value; }

        public string FullName()
        {
            return Prefix.Name + " " + name + " " + Suffix.Name;
        }
        public int TotalStrength()
        {
            // TODO: Add changes from all current status effects, entity suffixes, prefixes and traits
            return Strength + EquippedHead.TotalStrength() + EquippedBody.TotalStrength() + EquippedArms.TotalStrength() + EquippedGloves.TotalStrength() + EquippedMainHand.TotalStrength() + EquippedOffHand.TotalStrength() + EquippedLegs.TotalStrength() + EquippedFeet.TotalStrength();
        }
        public int TotalIntelligence()
        {
            // TODO: Add changes from all current status effects, entity suffixes, prefixes and traits
            return Intelligence + EquippedHead.TotalIntelligence() + EquippedBody.TotalIntelligence() + EquippedArms.TotalIntelligence() + EquippedGloves.TotalIntelligence() + EquippedMainHand.TotalIntelligence() + EquippedOffHand.TotalIntelligence() + EquippedLegs.TotalIntelligence() + EquippedFeet.TotalIntelligence();
        }
        public int TotalDexterity()
        {
            // TODO: Add changes from all current status effects, entity suffixes, prefixes and traits
            return Dexterity + EquippedHead.TotalDexterity() + EquippedBody.TotalDexterity() + EquippedArms.TotalDexterity() + EquippedGloves.TotalDexterity() + EquippedMainHand.TotalDexterity() + EquippedOffHand.TotalDexterity() + EquippedLegs.TotalDexterity() + EquippedFeet.TotalDexterity();
        }
        public int BasicLift()
        {
            return (int)Math.Pow(TotalStrength(), 2) / 5;
        }
        public int BasicThrust()
        {
            Dice dice = new Dice();
            if (TotalStrength() >= 1 && TotalStrength() <= 2)
            {
                return dice.RollTotal(1, 6) - 6;
            }
            else if (TotalStrength() >= 3 && TotalStrength() <= 4)
            {
                return dice.RollTotal(1, 6) - 5;
            }
            else if (TotalStrength() >= 5 && TotalStrength() <= 6)
            {
                return dice.RollTotal(1, 6) - 4;
            }
            else if (TotalStrength() >= 7 && TotalStrength() <= 8)
            {
                return dice.RollTotal(1, 6) - 3;
            }
            else if (TotalStrength() >= 9 && TotalStrength() <= 10)
            {
                return dice.RollTotal(1, 6) - 2;
            }
            else if (TotalStrength() >= 11 && TotalStrength() <= 12)
            {
                return dice.RollTotal(1, 6) - 1;
            }
            else if (TotalStrength() >= 13 && TotalStrength() <= 14)
            {
                return dice.RollTotal(1, 6);
            }
            else if (TotalStrength() >= 15 && TotalStrength() <= 16)
            {
                return dice.RollTotal(1, 6) + 1;
            }
            else if (TotalStrength() >= 17 && TotalStrength() <= 18)
            {
                return dice.RollTotal(1, 6) + 2;
            }
            else if (TotalStrength() >= 19 && TotalStrength() <= 20)
            {
                return dice.RollTotal(2, 6) - 1;
            }
            else if (TotalStrength() >= 21 && TotalStrength() <= 22)
            {
                return dice.RollTotal(2, 6);
            }
            else if (TotalStrength() >= 23 && TotalStrength() <= 24)
            {
                return dice.RollTotal(2, 6) + 1;
            }
            else if (TotalStrength() >= 25 && TotalStrength() <= 26)
            {
                return dice.RollTotal(2, 6) + 2;
            }
            else if (TotalStrength() >= 27 && TotalStrength() <= 28)
            {
                return dice.RollTotal(3, 6) - 1;
            }
            else if (TotalStrength() >= 29 && TotalStrength() <= 30)
            {
                return dice.RollTotal(3, 6);
            }
            else if (TotalStrength() >= 31 && TotalStrength() <= 32)
            {
                return dice.RollTotal(3, 6) + 1;
            }
            else if (TotalStrength() >= 33 && TotalStrength() <= 34)
            {
                return dice.RollTotal(3, 6) + 2;
            }
            else if (TotalStrength() >= 35 && TotalStrength() <= 36)
            {
                return dice.RollTotal(4, 6) - 1;
            }
            else if (TotalStrength() >= 37 && TotalStrength() <= 38)
            {
                return dice.RollTotal(4, 6);
            }
            else if (TotalStrength() >= 39 && TotalStrength() <= 44)
            {
                return dice.RollTotal(4, 6) + 1;
            }
            else if (TotalStrength() >= 45 && TotalStrength() <= 49)
            {
                return dice.RollTotal(5, 6);
            }
            else if (TotalStrength() >= 50 && TotalStrength() <= 54)
            {
                return dice.RollTotal(5, 6) + 2;
            }
            else if (TotalStrength() >= 55 && TotalStrength() <= 59)
            {
                return dice.RollTotal(6, 6);
            }
            else if (TotalStrength() >= 60 && TotalStrength() <= 64)
            {
                return dice.RollTotal(7, 6) - 1;
            }
            else if (TotalStrength() >= 65 && TotalStrength() <= 69)
            {
                return dice.RollTotal(7, 6) + 12;
            }
            else if (TotalStrength() >= 70 && TotalStrength() <= 74)
            {
                return dice.RollTotal(8, 6);
            }
            else if (TotalStrength() >= 75 && TotalStrength() <= 79)
            {
                return dice.RollTotal(8, 6) + 2;
            }
            else if (TotalStrength() >= 80 && TotalStrength() <= 84)
            {
                return dice.RollTotal(9, 6);
            }
            else if (TotalStrength() >= 85 && TotalStrength() <= 89)
            {
                return dice.RollTotal(9, 6) + 2;
            }
            else if (TotalStrength() >= 90 && TotalStrength() <= 94)
            {
                return dice.RollTotal(10, 6);
            }
            else if (TotalStrength() >= 95 && TotalStrength() <= 99)
            {
                return dice.RollTotal(10, 6) + 2;
            }
            else if (TotalStrength() >= 100)
            {
                int bonus = Convert.ToInt32((TotalStrength() - 100) / 10);
                return dice.RollTotal(11 + bonus, 6);
            }
            else
            {
                return 0;
            }

        }
        public int BasicSwing()
        {
            Dice dice = new Dice();
            if (TotalStrength() >= 1 && TotalStrength() <= 2)
            {
                return dice.RollTotal(1, 6) - 5;
            }
            else if (TotalStrength() >= 3 && TotalStrength() <= 4)
            {
                return dice.RollTotal(1, 6) - 4;
            }
            else if (TotalStrength() >= 5 && TotalStrength() <= 6)
            {
                return dice.RollTotal(1, 6) - 3;
            }
            else if (TotalStrength() >= 7 && TotalStrength() <= 8)
            {
                return dice.RollTotal(1, 6) - 2;
            }
            else if (TotalStrength() == 9)
            {
                return dice.RollTotal(1, 6) - 1;
            }
            else if (TotalStrength() == 10)
            {
                return dice.RollTotal(1, 6);
            }
            else if (TotalStrength() == 11)
            {
                return dice.RollTotal(1, 6) + 1;
            }
            else if (TotalStrength() == 12)
            {
                return dice.RollTotal(1, 6) + 2;
            }
            else if (TotalStrength() == 13)
            {
                return dice.RollTotal(2, 6) - 1;
            }
            else if (TotalStrength() == 14)
            {
                return dice.RollTotal(2, 6);
            }
            else if (TotalStrength() == 15)
            {
                return dice.RollTotal(2, 6) + 1;
            }
            else if (TotalStrength() == 16)
            {
                return dice.RollTotal(2, 6) + 2;
            }
            else if (TotalStrength() == 17)
            {
                return dice.RollTotal(3, 6) - 1;
            }
            else if (TotalStrength() == 18)
            {
                return dice.RollTotal(3, 6);
            }
            else if (TotalStrength() == 19)
            {
                return dice.RollTotal(3, 6) + 1;
            }
            else if (TotalStrength() == 20)
            {
                return dice.RollTotal(3, 6) + 2;
            }
            else if (TotalStrength() == 21)
            {
                return dice.RollTotal(4, 6) - 1;
            }
            else if (TotalStrength() == 22)
            {
                return dice.RollTotal(4, 6);
            }
            else if (TotalStrength() == 23)
            {
                return dice.RollTotal(4, 6) + 1;
            }
            else if (TotalStrength() == 24)
            {
                return dice.RollTotal(4, 6) + 2;
            }
            else if (TotalStrength() == 25)
            {
                return dice.RollTotal(5, 6) - 1;
            }
            else if (TotalStrength() == 26)
            {
                return dice.RollTotal(5, 6);
            }
            else if (TotalStrength() >= 27 && TotalStrength() <= 28)
            {
                return dice.RollTotal(5, 6) + 1;
            }
            else if (TotalStrength() >= 29 && TotalStrength() <= 30)
            {
                return dice.RollTotal(5, 6) + 2;
            }
            else if (TotalStrength() >= 31 && TotalStrength() <= 32)
            {
                return dice.RollTotal(6, 6) - 1;
            }
            else if (TotalStrength() >= 33 && TotalStrength() <= 34)
            {
                return dice.RollTotal(6, 6);
            }
            else if (TotalStrength() >= 35 && TotalStrength() <= 36)
            {
                return dice.RollTotal(6, 6) + 1;
            }
            else if (TotalStrength() >= 37 && TotalStrength() <= 38)
            {
                return dice.RollTotal(6, 6) + 2;
            }
            else if (TotalStrength() >= 39 && TotalStrength() <= 44)
            {
                return dice.RollTotal(7, 6) - 1;
            }
            else if (TotalStrength() >= 45 && TotalStrength() <= 49)
            {
                return dice.RollTotal(7, 6) + 1;
            }
            else if (TotalStrength() >= 50 && TotalStrength() <= 54)
            {
                return dice.RollTotal(8, 6) - 1;
            }
            else if (TotalStrength() >= 55 && TotalStrength() <= 59)
            {
                return dice.RollTotal(8, 6) + 1;
            }
            else if (TotalStrength() >= 60 && TotalStrength() <= 64)
            {
                return dice.RollTotal(9, 6);
            }
            else if (TotalStrength() >= 65 && TotalStrength() <= 69)
            {
                return dice.RollTotal(9, 6) + 2;
            }
            else if (TotalStrength() >= 70 && TotalStrength() <= 74)
            {
                return dice.RollTotal(10, 6);
            }
            else if (TotalStrength() >= 75 && TotalStrength() <= 79)
            {
                return dice.RollTotal(10, 6) + 2;
            }
            else if (TotalStrength() >= 80 && TotalStrength() <= 84)
            {
                return dice.RollTotal(11, 6);
            }
            else if (TotalStrength() >= 85 && TotalStrength() <= 89)
            {
                return dice.RollTotal(11, 6) + 2;
            }
            else if (TotalStrength() >= 90 && TotalStrength() <= 94)
            {
                return dice.RollTotal(12, 6);
            }
            else if (TotalStrength() >= 95 && TotalStrength() <= 99)
            {
                return dice.RollTotal(12, 6) + 2;
            }
            else if (TotalStrength() >= 100)
            {
                int bonus = Convert.ToInt32((TotalStrength() - 100) / 10);
                return dice.RollTotal(13 + bonus, 6);
            }
            else
            {
                return 0;
            }

        }
        public double BasicSpeed()
        {
            return (MaxHealth + TotalDexterity()) / 2;
        }
        public int TotalDamage()
        {
            // TODO: Add changes from all current status effects, entity suffixes, prefixes and traits
            return EquippedHead.TotalDamage() + EquippedBody.TotalDamage() + EquippedArms.TotalDamage() + EquippedGloves.TotalDamage() + EquippedMainHand.TotalDamage() + EquippedOffHand.TotalDamage() + EquippedLegs.TotalDamage() + EquippedFeet.TotalDamage();
        }
        public void UnarmedAttack(Entity target)
        {
            int defactoDamage = BasicThrust() - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (defactoDamage < 0)
            {
                defactoDamage = 0;
            }
            target.CurrentHealth -= defactoDamage;
            return;
        }
        public void UnarmedAttack(Entity target, Equipment bodyPart)
        {
            int defactoDamage = BasicThrust() - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (defactoDamage < 0)
            {
                defactoDamage = 0;
            }
            target.CurrentHealth -= defactoDamage;
            return;
        }
    }
}