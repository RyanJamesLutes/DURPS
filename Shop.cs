using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot
{
    class Shop
    {
        private List<Item> inventory = new List<Item>();

        internal List<Item> Inventory { get => inventory; set => inventory = value; }
    }
}
