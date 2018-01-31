using Discord.WebSocket;
using System;

namespace DURPSBot
{
    [Serializable]
    class PlayerCharacter : Entity
    {
        private string characterClass = "fool";
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

        public override void Die(Entity killer)
        {
            losses += 1;
            CurrentHitPoints = MaxHitPoints;
        }

        public PlayerCharacter(string cc, ulong uid, string n)
        {
            DataManager dm = new DataManager();
            Random rng = new Random();
            UserID = uid;
            Name = n;

            CharacterClass = cc;
            Level = 1;
            Experience = 0;
            CurrentHitPoints = MaxHitPoints;
            Speed = (Health + TotalDexterity()) / 2;
            FatiguePoints = Health;

            if (CharacterClass.ToLower() == "jack")
            {
                Strength = 10;
                Dexterity = 10;
                Intelligence = 10;
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedFeet = new Items.Equipment.LeatherBoots();
            }
            else if (CharacterClass.ToLower() == "warrior")
            {
                Strength = rng.Next(10, 14);
                Dexterity = rng.Next(8, 12);
                Intelligence = rng.Next(8, 12);
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedMainHand = new Items.Equipment.Shortsword();
                EquippedFeet = new Items.Equipment.LeatherBoots();
            }
            else if (CharacterClass.ToLower() == "rogue")
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
            else if (CharacterClass.ToLower() == "mage")
            {
                Strength = rng.Next(8, 12);
                Dexterity = rng.Next(8, 12);
                Intelligence = rng.Next(10, 14);
                Luck = rng.Next(1, 14);
                Fate = rng.Next(1, 14);

                EquippedBody = new Items.Equipment.Robes();
                EquippedFeet = new Items.Equipment.Sandals();
            }
            else if (CharacterClass.ToLower() == "fool")
            {
                Strength = 8;
                Dexterity = 8;
                Intelligence = 8;
                Luck = 14;
                Fate = rng.Next(1, 14);

                EquippedHead = new Items.Equipment.JestersCap();
            }
            else if (CharacterClass.ToLower() == "wanderer")
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

            dm.Save(this);
        }
    }
}