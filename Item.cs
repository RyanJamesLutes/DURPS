using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot
{
    [Serializable]
    class Item
    {
        private string name;
        private double weight;
        private int price;
        private string itemID;
        private string description;
        private bool dropsOnDeath;
        private double dropPercent;
        private byte techLevel = 0;

        public string Name { get => name; set => name = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Price { get => price; set => price = value; }
        public string ItemID { get => itemID; set => itemID = value; }
        public string Description { get => description; set => description = value; }
        public bool DropsOnDeath { get => dropsOnDeath; set => dropsOnDeath = value; }
        public double DropPercent { get => dropPercent; set => dropPercent = value; }
        public byte TechLevel { get => techLevel; set => techLevel = value; }

        public string GenerateItemID()
        {
            return Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds) + " - " + Convert.ToString(new Random().Next(1000, 9999));
        }
    }
}