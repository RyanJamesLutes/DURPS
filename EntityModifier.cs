using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot
{
    [Serializable]
    class EntityModifier
    {
        private string name;
        private int level;
        private int health;
        private int strength;
        private int intelligence;
        private int dexterity;
        private int defenseBonus;

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public int Health { get => health; set => health = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int DefenseBonus { get => defenseBonus; set => defenseBonus = value; }
    }
}
