using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DURPSBot.Items.Equipment;

namespace DURPSBot
{
    class Shop
    {
        private List<Equipment> inStock = new List<Equipment>();
        private Random rng;

        internal List<Equipment> InStock { get => inStock; set => inStock = value; }

        public void Stock()
        {
            List<Equipment> toStock = new List<Equipment>()
        {
            new Blackjack(),
            new BrassKnuckles(),
            new BronzeArmbands(),
            new Chainsaw(),
            new Cloak(),
            new Dagger(),
            new FurLoincloth(),
            new LeatherBoots(),
            new LeatherGloves(),
            new LeatherJacket(),
            new LeatherPants(),
            new LongStaff(),
            new Mace(),
            new Quarterstaff(),
            new Robes(),
            new Sandals(),
            new Shortsword()
        };

            while (InStock.Count < 8)
            {
                InStock.Add(toStock[rng.Next(toStock.Count - 1)]);
            }

        }

        public Shop()
        {
            rng = new Random(0 - Int32.Parse(DateTime.Now.Date.ToString("ddMMyy")));
            Stock();
            foreach (Equipment e in InStock)
            {
                // TODO: Use totals when modifiers are added.
                e.Price *= 1 + (rng.Next(25) / 100);
            }
        }
    }
}
