using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    [TestFixture]
    public class TestLookCommand
    {
        // arrange
        LookCommand lookCommand;
        Player player;
        string[] commandInput;

        Item sword;
        Item shield;



        [SetUp]
        public void SetUp()
        {
            lookCommand = new LookCommand();
            player = new Player("Aaron", "A mighty programmer");

            sword = new Item(new string[] { "sword" }, "my sword", "A finely crafted sharp sword.");
            shield = new Item(new string[] { "shield" }, "my shield", "A sturdy wooden shield.");
            
        }

        // act and assert
        [Test]
        public void TestLookAtMe()
        {
            Item gem = new Item(new string[] { "gem" }, "my gem", "A bright red gem");

            player.Inventory.Put(sword);
            player.Inventory.Put(shield);
            player.Inventory.Put(gem);

            List<string> items = player.Inventory.ItemList;
            List<string> expectedItems = new List<string>()
            {
                "\tmy sword (sword)",
                "\tmy shield (shield)",
                "\tmy gem (gem)",
            };

            Assert.That(items, Is.EqualTo(expectedItems));
        }

        [Test]
        public void TestLookAtGem()
        {
            Item gem = new Item(new string[] { "gem" }, "my gem", "A bright red gem");

            player.Inventory.Put(gem);

            commandInput = new string[] { "look", "at", "gem" };
            string result = lookCommand.Execute(player, commandInput);

            Assert.That(result, Is.EqualTo("A bright red gem"));
        }

        [Test]
        public void TestLookAtUnk()
        {

            commandInput = new string[] { "look", "at", "gem" };
            string result = lookCommand.Execute(player, commandInput);

            Assert.That(result, Is.EqualTo("I can't find the gem"));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            Item gem = new Item(new string[] { "gem" }, "my gem", "A bright red gem");

            player.Inventory.Put(gem);
            commandInput = new string[] { "look", "at", "gem", "in", "inventory" };
            string result = lookCommand.Execute(player, commandInput);

            Assert.That(result, Is.EqualTo("A bright red gem"));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            Item gem = new Item(new string[] { "gem" }, "my gem", "A bright red gem");
            Bag bag = new Bag(new string[] { "bag", "backpack" }, "my bag", "A sturdy leather backpack.");

            player.Inventory.Put(bag);
            bag.Inventory.Put(gem);
            
            commandInput = new string[] { "look", "at", "gem", "in", "bag" };
            string result = lookCommand.Execute(player, commandInput);

            Assert.That(result, Is.EqualTo("A bright red gem"));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {

            commandInput = new string[] { "look", "at", "gem", "in", "bag" };
            string result = lookCommand.Execute(player, commandInput);

            Assert.That(result, Is.EqualTo("I can't find the bag"));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            Item potion = new Item(new string[] { "potion" }, "a healing potion", "A small vial of healing potion.");
            Bag bag = new Bag(new string[] { "bag", "backpack" }, "my bag", "A sturdy leather backpack.");

            player.Inventory.Put(bag);
            bag.Inventory.Put(potion);

            commandInput = new string[] { "look", "at", "gem", "in", "bag" };
            string result = lookCommand.Execute(player, commandInput);

            Assert.That(result, Is.EqualTo("I can't find the gem"));
        }

        [Test]
        public void TestInvalidLook()
        {
            string[] commandInput1, commandInput2, commandInput3, commandInput4;

            commandInput1 = new string[] { "look", "around" };
            string result1 = lookCommand.Execute(player, commandInput1);

            commandInput2 = new string[] { "hello" };
            string result2 = lookCommand.Execute(player, commandInput2);

            commandInput3 = new string[] { "look", "at", "pen" };
            string result3 = lookCommand.Execute(player, commandInput3);

            commandInput4 = new string[] { "look", "at", "phone", "in", "purse" };
            string result4 = lookCommand.Execute(player, commandInput4);

            Assert.That(result1, Is.EqualTo("I don't know how to look like that"));
            Assert.That(result2, Is.EqualTo("I don't know how to look like that"));
            Assert.That(result3, Is.EqualTo("I can't find the pen"));
            Assert.That(result4, Is.EqualTo("I can't find the purse"));
        }
    }
}
