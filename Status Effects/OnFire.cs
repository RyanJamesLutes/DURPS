using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot.Status_Effects
{
    class OnFire : StatusEffect
    {
        public OnFire()
        {
            Name = "On Fire";
            Duration = 255;
            Damage = new Random().Next(1,6) - 4;
            if (Damage < 0)
            {
                Damage = 0;
            }
            IsPositiveEffect = false;
        }

        public override void Tick(Entity target)
        {
            base.Tick(target);
            // Todo: Dexterity penalty
        }
    }
}
