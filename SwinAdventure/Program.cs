using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Inventory _inventory = new Inventory();

            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item gem = new Item(new string[] { "gem", "treasure" }, "a gem", "This is a mighty fine gem");
            _inventory.Put(shovel);
            _inventory.Put(gem);
            List<string> items = _inventory.ItemList;

            foreach (string item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
