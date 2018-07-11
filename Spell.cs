using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot
{
    [Serializable]
    class Spell
    {
        private string name;
        private string college;
        private string description;
        private byte manaLevel; // 0 = No Mana, 1 = Low Mana, 2 = Normal Mana, 3 = High Mana, 4 = Very High Mana. See Page 235 of GURPS 4th Edition - Basic Set
        private byte skillLevel = 2;
        private bool usesFatigue = false;
        private int minFatigueCost;
        private int maxFatigueCost;
        private bool usesHealth = false;
        private int minHealthCost;
        private int maxHealthCost;
        private bool isAOE;
        private int minAOE;
        private int maxAOE;
        private List<Spell> prerequisites;

        public string Name { get => name; set => name = value; }
        public string College { get => college; set => college = value; }
        public string Description { get => description; set => description = value; }
        public byte ManaLevel { get => manaLevel; set => manaLevel = value; }
        public byte SkillLevel { get => skillLevel; set => skillLevel = value; }
        public int MinFatigueCost { get => minFatigueCost; set => minFatigueCost = value; }
        public int MaxFatigueCost { get => maxFatigueCost; set => maxFatigueCost = value; }
        public int MinHealthCost { get => minHealthCost; set => minHealthCost = value; }
        public int MaxHealthCost { get => maxHealthCost; set => maxHealthCost = value; }
        public bool IsAOE { get => isAOE; set => isAOE = value; }
        public int MinAOE { get => minAOE; set => minAOE = value; }
        public int MaxAOE { get => maxAOE; set => maxAOE = value; }
        public bool UsesFatigue { get => usesFatigue; set => usesFatigue = value; }
        public bool UsesHealth { get => usesHealth; set => usesHealth = value; }
        internal List<Spell> Prerequisites { get => prerequisites; set => prerequisites = value; }

        public virtual void Cast()
        {

        }
        public virtual void Cast(Entity target)
        {

        }
        public virtual void Cast(Entity caster, Entity target)
        {

        }
    }
}
