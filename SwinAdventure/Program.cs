﻿using NUnit.Framework;
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
            // Step 1: Get Player Details
            Console.Write("Enter your player's name: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter your player's description: ");
            string playerDescription = Console.ReadLine();

            Player player = new Player(playerName, playerDescription);

            // Step 2: Create Items and Add to Inventory
            Item sword = new Item(new string[] { "sword" }, "a sharp sword", "A finely crafted sharp sword.");
            Item shield = new Item(new string[] { "shield" }, "a sturdy shield", "A sturdy wooden shield.");
            player.Inventory.Put(sword);
            player.Inventory.Put(shield);

            // Step 3: Create Bag and Add to Inventory
            Bag bag = new Bag(new string[] { "bag", "small bag" }, "a small bag", "A small leather bag.");
            player.Inventory.Put(bag);

            // Step 4: Add an Item to the Bag
            Item potion = new Item(new string[] { "potion" }, "a healing potion", "A small vial of healing potion.");
            bag.Inventory.Put(potion);

            // Step 5: Command Loop
            LookCommand lookCommand = new LookCommand();
            string[] commandInput;

            while (true)
            {
                Console.WriteLine("\nEnter a command (or 'quit' to exit):");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                commandInput = input.Split(' ');

                string result = lookCommand.Execute(player, commandInput);
                Console.WriteLine(result);
            }

        }
    }
   
}
