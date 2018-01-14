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
        private long level;
        private long health;
        private long strength;
        private long intelligence;
        private long dexterity;
        private long defenseBonus;

        public string Name { get => name; set => name = value; }
        public long Level { get => level; set => level = value; }
        public long Health { get => health; set => health = value; }
        public long Strength { get => strength; set => strength = value; }
        public long Intelligence { get => intelligence; set => intelligence = value; }
        public long Dexterity { get => dexterity; set => dexterity = value; }
        public long DefenseBonus { get => defenseBonus; set => defenseBonus = value; }
    }
}
