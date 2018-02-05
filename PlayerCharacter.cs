using Discord.WebSocket;
using System;

namespace DURPSBot
{
    [Serializable]
    class PlayerCharacter : Entity
    {
        private string characterClass = "Fool";
        private uint traitPoints = 0;
        private string fileVersion = "1.00";
        private ulong userID = 0;

        private int killedGiantRats = 0;
        private int killedDireWolves = 0;
        private int killedUnicorns = 0;
        private int killedZombies = 0;
        private int wins = 0;
        private int losses = 0;

        public uint TraitPoints { get => traitPoints; set => traitPoints = value; }
        public string FileVersion { get => fileVersion; set => fileVersion = value; }
        public ulong UserID { get => userID; set => userID = value; }
        public int KilledGiantRats { get => killedGiantRats; set => killedGiantRats = value; }
        public int KilledDireWolves { get => killedDireWolves; set => killedDireWolves = value; }
        public int KilledZombies { get => killedZombies; set => killedZombies = value; }
        public int KilledUnicorns { get => killedUnicorns; set => killedUnicorns = value; }
        public int Wins { get => wins; set => wins = value; }
        public int Losses { get => losses; set => losses = value; }
        public string CharacterClass { get => characterClass; set => characterClass = value; }

        public int TotalKills()
        {
            int kills = KilledGiantRats + KilledDireWolves + KilledUnicorns + KilledZombies;
            return kills;
        }

        public void Die()
        {
            DataManager dm = new DataManager();
            Losses++;
            CurrentHitPoints = MaxHitPoints;
            dm.Save(this);
        }

        public PlayerCharacter(string cc, ulong uid, string n)
        {
            DataManager dm = new DataManager();
            Random rng = new Random();
            UserID = uid;
            Name = n;

            Level = 1;
            Experience = 0;
            CurrentHitPoints = MaxHitPoints;
            Speed = (Health + TotalDexterity()) / 2;
            FatiguePoints = Health;

            if (cc.ToLower() == "jack")
            {
                CharacterClass = "Jack";
                Strength = 10;
                Dexterity = 10;
                Intelligence = 10;
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedFeet = new Items.Equipment.LeatherBoots();
            }
            else if (cc.ToLower() == "warrior")
            {
                CharacterClass = "Warrior";
                Strength = rng.Next(10, 14);
                Dexterity = rng.Next(8, 12);
                Intelligence = rng.Next(8, 12);
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedMainHand = new Items.Equipment.Shortsword();
                EquippedFeet = new Items.Equipment.LeatherBoots();
            }
            else if (cc.ToLower() == "rogue")
            {
                CharacterClass = "Rogue";
                Strength = rng.Next(8, 12);
                Dexterity = rng.Next(10, 14);
                Intelligence = rng.Next(8, 12);
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedBody = new Items.Equipment.Cloak();
                EquippedMainHand = new Items.Equipment.Dagger();
                EquippedFeet = new Items.Equipment.LeatherBoots();
            }
            else if (cc.ToLower() == "mage")
            {
                CharacterClass = "Mage";
                Strength = rng.Next(8, 12);
                Dexterity = rng.Next(8, 12);
                Intelligence = rng.Next(10, 14);
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedBody = new Items.Equipment.Robes();
                EquippedFeet = new Items.Equipment.Sandals();
            }
            else if (cc.ToLower() == "wanderer")
            {
                CharacterClass = "Wanderer";
                Strength = 8;
                Dexterity = 8;
                Intelligence = 8;
                Luck = rng.Next(1, 14);
                Fate = 14;

                EquippedFeet = new Items.Equipment.LeatherBoots();
            }
            //else if (cc.ToLower() == "test")
            //{
            //    CharacterClass = "test";
            //    Strength = 255;
            //    Dexterity = 255;
            //    Intelligence = 255;
            //    Luck = 255;
            //    Fate = 255;

            //    EquippedHead = new Items.Equipment.JestersCap();
            //    EquippedBody = new Items.Equipment.Cloak();
            //    EquippedMainHand = new Items.Equipment.Shortsword();
            //    EquippedFeet = new Items.Equipment.LeatherBoots();
            //}
            else
            {
                CharacterClass = "Fool";
                Strength = 8;
                Dexterity = 8;
                Intelligence = 8;
                Luck = 14;
                Fate = rng.Next(1, 14);

                EquippedHead = new Items.Equipment.JestersCap();
            }

            Health = rng.Next(8,12);
            CurrentHitPoints = TotalStrength();
            MaxHitPoints = TotalStrength();
            Perception = TotalIntelligence();
            Willpower = TotalIntelligence();

            dm.Save(this);
        }
    }
}