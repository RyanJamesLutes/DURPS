using System;

namespace DURPSBot
{
    [Serializable]
    class StatusEffect : EntityModifier
    {
        private long duration;

        public long Duration { get => duration; set => duration = value; }
    }
}
