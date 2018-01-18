using System;

namespace DURPSBot
{
    [Serializable]
    class PlayerCharacter : Entity
    {
        private string userID;
        private string characterClass;
        private uint traitPoints;
        private string fileVersion;
        private int killedGiantRats = 0;
        private int killedDireWolves = 0;

        public string UserID { get => userID; set => userID = value; }
        public uint TraitPoints { get => traitPoints; set => traitPoints = value; }
        public string FileVersion { get => fileVersion; set => fileVersion = value; }

        public PlayerCharacter(string cc)
        {
            Random rng = new Random();

            characterClass = cc;
            Level = 1;
            Experience = 0;
            CurrentHitPoints = MaxHitPoints;
            Speed = (Health + TotalDexterity()) / 2;
            FatiguePoints = Health;

            if (characterClass == "Jack")
            {
                Strength = 10;
                Dexterity = 10;
                Intelligence = 10;
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedFeet = new Items.Equipment.LeatherBoots();
            }
            else if (characterClass == "Warrior")
            {
                Strength = rng.Next(10, 14);
                Dexterity = rng.Next(8, 12);
                Intelligence = rng.Next(8, 12);
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedMainHand = new Items.Equipment.Shortsword();
                EquippedFeet = new Items.Equipment.LeatherBoots();
            }
            else if (characterClass == "Rogue")
            {
                Strength = rng.Next(8, 12);
                Dexterity = rng.Next(10, 14);
                Intelligence = rng.Next(8, 12);
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedBody = new Items.Equipment.Cloak();
                EquippedMainHand = new Items.Equipment.Dagger();
                EquippedFeet = new Items.Equipment.LeatherBoots();
            }
            else if (characterClass == "Mage")
            {
                Strength = rng.Next(8, 12);
                Dexterity = rng.Next(8, 12);
                Intelligence = rng.Next(10, 14);
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedBody = new Items.Equipment.Robes();
                EquippedFeet = new Items.Equipment.Sandals();
            }
            else if (characterClass == "Fool")
            {
                Strength = 8;
                Dexterity = 8;
                Intelligence = 8;
                Luck = 14;
                Fate = rng.Next(1, 14);

                EquippedHead = new Items.Equipment.JestersCap();
            }
            else if (characterClass == "Wanderer")
            {
                Strength = 8;
                Dexterity = 8;
                Intelligence = 8;
                Luck = rng.Next(1, 14);
                Fate = 14;

                EquippedFeet = new Items.Equipment.LeatherBoots();
            }

            Health = rng.Next(8,12);
            MaxHitPoints = TotalStrength();
            Perception = TotalIntelligence();
            Willpower = TotalIntelligence();
        }
    }
}