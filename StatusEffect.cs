using System;

namespace DURPSBot
{
    [Serializable]
    class StatusEffect : EntityModifier
    {
        private int duration; // Combat rounds.
        private int damage; // Damage dealt per round.
        private bool isPositiveEffect;

        public int Duration { get => duration; set => duration = value; }
        public int Damage { get => damage; set => damage = value; }
        public bool IsPositiveEffect { get => isPositiveEffect; set => isPositiveEffect = value; }

        public virtual void Tick(Entity target)
        {
            if (duration == 0)
            {
                EndEffect(target);
            }
            else
            {
                duration--;
            }
        }

        public virtual void EndEffect(Entity target)
        {
            target.StatusEffect.Remove(this);
        }
    }
}
