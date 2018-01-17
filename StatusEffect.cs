using System;

namespace DURPSBot
{
    [Serializable]
    class StatusEffect : EntityModifier
    {
        private int duration;

        public int Duration { get => duration; set => duration = value; }
    }
}
