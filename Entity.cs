using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DURPSBot
{
    [Serializable]
    class Entity
    {
        private EntityPrefix prefix = new EntityPrefix();
        private string name = "";
        private EntitySuffix suffix = new EntitySuffix();
        private int level = 0;
        private long experience = 0;
        private int currentHitPoints = 0;
        private int maxHitPoints = 0;
        private int strength = 0;
        private int intelligence = 0;
        private int dexterity = 0;
        private int luck = 0;
        private int fate = 0;
        private int damageResistance = 0;
        private List<Trait> traits = new List<Trait>();
        private List<StatusEffect> statusEffect = new List<StatusEffect>();
        private Equipment equippedHead = new Items.Equipment.Empty();
        private Equipment equippedBody = new Items.Equipment.Empty();
        private Equipment equippedArms = new Items.Equipment.Empty();
        private Equipment equippedGloves = new Items.Equipment.Empty();
        private Equipment equippedMainHand = new Items.Equipment.Empty();
        private Equipment equippedOffHand = new Items.Equipment.Empty();
        private Equipment equippedLegs = new Items.Equipment.Empty();
        private Equipment equippedFeet = new Items.Equipment.Empty();
        private List<Equipment> inventoryEquipment = new List<Equipment>();
        private long money = 0;
        private double speed = 0; // Default = (Health + Dexterity) / 2
        private int fatiguePoints = 0;
        private int health = 0;
        private int willpower = 0;
        private int perception = 0;
        private string description = "";
        private int sizeModifier = 0;
        private int dodge = 0;
        private bool canFatigue = false;
        private bool canDodge = false;
        private bool canParry = false;
        private int parry = 0;
        private int move = 0;

        [OptionalField]
        private List<Spell> spells = new List<Spell>();
        [OptionalField]
        private string collegeFocus = "";

        // Inventory and equipment
        public Equipment EquippedHead { get => equippedHead; set => equippedHead = value; }
        public Equipment EquippedBody { get => equippedBody; set => equippedBody = value; }
        public Equipment EquippedArms { get => equippedArms; set => equippedArms = value; }
        public Equipment EquippedGloves { get => equippedGloves; set => equippedGloves = value; }
        public Equipment EquippedMainHand { get => equippedMainHand; set => equippedMainHand = value; }
        public Equipment EquippedOffHand { get => equippedOffHand; set => equippedOffHand = value; }
        public Equipment EquippedLegs { get => equippedLegs; set => equippedLegs = value; }
        public Equipment EquippedFeet { get => equippedFeet; set => equippedFeet = value; }
        public List<Equipment> InventoryEquipment { get => inventoryEquipment; set => inventoryEquipment = value; }
        public long Money { get => money; set => money = value; }

        // Base attributes and modifiers
        internal EntityPrefix Prefix { get => prefix; set => prefix = value; }
        public string Name { get => name; set => name = value; }
        internal EntitySuffix Suffix { get => suffix; set => suffix = value; }
        public int Level { get => level; set => level = value; }
        public long Experience { get => experience; set => experience = value; }
        public int CurrentHitPoints { get => currentHitPoints; set => currentHitPoints = value; }
        public int MaxHitPoints { get => maxHitPoints; set => maxHitPoints = value; }
        public int FatiguePoints { get => fatiguePoints; set => fatiguePoints = value; }
        public int Willpower { get => willpower; set => willpower = value; }
        public int Perception { get => perception; set => perception = value; }
        public int Health { get => health; set => health = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Luck { get => luck; set => luck = value; }
        public int Fate { get => fate; set => fate = value; }
        public int DamageResistance { get => damageResistance; set => damageResistance = value; }
        internal List<Trait> Traits { get => traits; set => traits = value; }
        internal List<StatusEffect> StatusEffect { get => statusEffect; set => statusEffect = value; }
        public double Speed { get => speed; set => speed = value; }
        public string Description { get => description; set => description = value; }
        public int SizeModifier { get => sizeModifier; set => sizeModifier = value; }
        public bool CanParry { get => canParry; set => canParry = value; }
        public int Move { get => move; set => move = value; }
        public int Dodge { get => dodge; set => dodge = value; }
        public bool CanDodge { get => canDodge; set => canDodge = value; }
        public bool CanFatigue { get => canFatigue; set => canFatigue = value; }
        public int Parry { get => parry; set => parry = value; }
        internal List<Spell> Spells { get => spells; set => spells = value; }

        public string FullName()
        {
            return Prefix.Name + " " + name + " " + Suffix.Name;
        }
        public List<Equipment> AllEquipped()
        {
            List<Equipment> equipList = new List<Equipment> { EquippedHead, EquippedBody, EquippedArms, EquippedGloves, EquippedMainHand, EquippedOffHand, EquippedLegs, EquippedFeet };
            return equipList;
        }
        public int TotalStrength()
        {
            // TODO: Add changes from all current status effects, entity suffixes, prefixes and traits
            int totalStrength = Strength;
            foreach (Equipment e in AllEquipped())
            {
                totalStrength += e.TotalStrength();
            }
            return totalStrength;
        }
        public int TotalIntelligence()
        {
            // TODO: Add changes from all current status effects, entity suffixes, prefixes and traits
            int totalIntelligence = Intelligence;
            foreach (Equipment e in AllEquipped())
            {
                totalIntelligence += e.TotalIntelligence();
            }
            return totalIntelligence;
        }
        public int TotalDexterity()
        {
            // TODO: Add changes from all current status effects, entity suffixes, prefixes and traits
            int totalDexterity = Dexterity;
            foreach (Equipment e in AllEquipped())
            {
                totalDexterity += e.TotalDexterity();
            }
            return totalDexterity;
        }
        public int TotalLuck()
        {
            // TODO: Add changes from all current status effects, entity suffixes, prefixes and traits
            int totalLuck = Luck;
            foreach (Equipment e in AllEquipped())
            {
                totalLuck += e.TotalLuck();
            }
            return totalLuck;
        }
        public int TotalFate()
        {
            // TODO: Add changes from all current status effects, entity suffixes, prefixes and traits
            int totalFate = Luck;
            foreach (Equipment e in AllEquipped())
            {
                totalFate += e.TotalFate();
            }
            return totalFate;
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
        public bool IsUnarmed()
        {

            foreach (Equipment eq in AllEquipped())
            {
                if (eq.IsWeapon)
                {
                    return false;
                }
            }
            return true;
        }
        public void UnarmedAttack(Entity target)
        {
            int penetratingDamage = BasicThrust() - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
        public void UnarmedAttack(Entity target, Equipment bodyPart)
        {
            int penetratingDamage = BasicThrust() - (target.DamageResistance + target.EquippedBody.DamageResistance);
            if (penetratingDamage < 0)
            {
                penetratingDamage = 0;
            }
            target.CurrentHitPoints -= penetratingDamage;
            return;
        }
        public void Unequip(Equipment equipmentSlot)
        {
            if (equipmentSlot is Items.Equipment.Empty == false)
            {
                InventoryEquipment.Add(equipmentSlot);
                equipmentSlot = new Items.Equipment.Empty();
            }
        }
        public void Equip(Equipment equipment)
        {
            if (MeetsRequirements(equipment))
            {
                if (equipment.EquipsToMainHand)
                {
                    if (equipment.IsTwoHanded)
                    {
                        Unequip(EquippedOffHand);
                    }
                    Unequip(EquippedMainHand);
                    EquippedMainHand = equipment;
                    InventoryEquipment.Remove(equipment);
                }
                else if (equipment.EquipsToOffHand)
                {
                    Unequip(EquippedOffHand);
                    EquippedOffHand = equipment;
                    InventoryEquipment.Remove(equipment);
                }
                else if (equipment.EquipsToBody)
                {
                    Unequip(EquippedBody);
                    EquippedBody = equipment;
                    InventoryEquipment.Remove(equipment);
                }
                else if (equipment.EquipsToArms)
                {
                    Unequip(EquippedArms);
                    EquippedArms = equipment;
                    InventoryEquipment.Remove(equipment);
                }
                else if (equipment.EquipsToGloves)
                {
                    Unequip(EquippedGloves);
                    EquippedGloves = equipment;
                    InventoryEquipment.Remove(equipment);
                }
                else if (equipment.EquipsToLegs)
                {
                    Unequip(EquippedLegs);
                    EquippedLegs = equipment;
                    InventoryEquipment.Remove(equipment);
                }
                else if (equipment.EquipsToFeet)
                {
                    Unequip(EquippedFeet);
                    EquippedFeet = equipment;
                    InventoryEquipment.Remove(equipment);
                }
            }
        }
        public bool MeetsRequirements(Equipment e)
        {
            if (
                TotalStrength() >= e.TotalRequiredStrength()
                && TotalIntelligence() >= e.TotalRequiredIntelligence()
                && TotalDexterity() >= e.TotalRequiredDexterity()
                && TotalLuck() >= e.TotalRequiredLuck()
                && TotalFate() >= e.TotalRequiredFate()
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void BattleAction(Entity target)
        {
            // TODO: Spellcasting
            if (IsUnarmed())
            {
                UnarmedAttack(target);
            }
            else
            {
                EquippedMainHand.BattleAction(this, target);
            }
        }
        public virtual void BattleAction(Entity target, Equipment bodyPart)
        {
            // TODO: Spellcasting
            if (IsUnarmed())
            {
                UnarmedAttack(target, bodyPart);
            }
            else
            {
                EquippedMainHand.BattleAction(this, target, bodyPart);
            }
        }
        public virtual void Die(PlayerCharacter killer)
        {
        }
    }
}