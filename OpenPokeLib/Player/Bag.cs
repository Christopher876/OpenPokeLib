using System;
using System.Collections.Generic;
using OpenPokeLib.Items;

namespace OpenPokeLib.Player
{
    public class Bag
    {
        public Dictionary<string,int> BagItems;
        private readonly int _maxCount = 999;

        public Bag()
        {
            BagItems = new Dictionary<string,int>();
        }

        public void AddItem(Item item)
        {
            if (BagItems.ContainsKey(item.Name))
            {
                if (BagItems[item.Name] <= _maxCount)
                    BagItems[item.Name]++;
                else
                {
                    Console.WriteLine($"{item.Name} is full in the bag");
                }
            }
            else
            {
                BagItems[item.Name] = 1;
            }
        }

        public IItem GeItem(string name)
        {
            if (BagItems.ContainsKey(name))
            {
                return new Item(name);
            }

            return null;
        }
    }
}