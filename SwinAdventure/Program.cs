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
            Player player = new Player("Aaron", "A mighty programmer");

            //bool result1 = player.AreYou("me");
            //bool result2 = player.AreYou("inventory");

            //Console.WriteLine(result1);
            //Console.WriteLine(result2);

            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item sword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "This is a mighty fine sword");
            Item computer = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a mighty fine computer");

            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            player.Inventory.Put(computer);


            GameObject item = player.Locate("shovel");
            Console.WriteLine(item.ShortDescription);
            Console.WriteLine(player.Inventory.ItemList.Count);

            GameObject p = player.Locate("gem");


            if (p == null)
                Console.WriteLine("the player does not have this item");
            else
                Console.WriteLine(p.Name);


            string s = player.FullDescription;

            Console.WriteLine(s);



        }
    }
   
}
