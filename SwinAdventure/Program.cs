using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;   

namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bag bag = new Bag(new string[] { "leather bag", "backpack" }, "my bag", "A sturdy leather bag.");
            Item potion = new Item(new string[] { "potion", "health potion" }, "my potion", "A small health potion.");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            bag.Inventory.Put(potion);
            bag.Inventory.Put(shovel);

            Bag purse = new Bag(new string[] { "red purse", "a small purse" }, "my purse", "A quality purse.");
            bag.Inventory.Put(purse);
            string fd = bag.FullDescription;
            Console.WriteLine(fd);



        }
    }
   
}
