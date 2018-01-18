using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot
{
    class Battle
    {
        private List<Entity> turnOrder = new List<Entity>();

        public Battle(params Entity[] participants)
        {
            for (int i = 0; i < participants.Length; i++)
            {
                turnOrder.Add(participants[i]);
            }
            turnOrder.Sort((a, b) => 
            {
                return a.Speed.CompareTo(b.Speed);
            });
            turnOrder.Reverse();
        }
    }
}