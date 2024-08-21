using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    [TestFixture]
    public class TestLookCommand
    {
        // arrange
        Bag bag;

        [SetUp]
        public void SetUp()
        {
            bag = new Bag(new string[] { "leather bag", "backpack" }, "my bag", "A sturdy leather backpack.");
        }

        // act and assert
        [Test]
        public void TestBagLocatesItems()
        {
            Item potion = new Item(new string[] { "potion", "health potion" }, "my potion", "A small health potion.");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            bag.Inventory.Put(potion);
            bag.Inventory.Put(shovel);

            string itemsDescription = string.Join("\n", bag.Inventory.ItemList);

            Assert.That(bag.FullDescription, Is.EqualTo($"In the {bag.Name}, you can see:\n{itemsDescription}"));
            Assert.That(bag.Inventory.ItemList.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestBagLocatesItself()
        {
            GameObject b2 = bag.Locate("leather bag");
            GameObject b1 = bag.Locate("backpack");

            Assert.That(b1.Name, Is.EqualTo("my bag"));
            Assert.That(b2.Name, Is.EqualTo("my bag"));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            GameObject b = bag.Locate("gem");

            Assert.That(b, Is.Null);
        }

        [Test]
        public void TestBagFullDescription()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item sword = new Item(new string[] { "sword", "short sword" }, "a bronze sword", "This is a mighty fine sword");
            Item computer = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a mighty fine computer");

            bag.Inventory.Put(shovel);
            bag.Inventory.Put(sword);
            bag.Inventory.Put(computer);

            string fd = string.Join("\n", bag.Inventory.ItemList);
            Assert.That(bag.FullDescription, Is.EqualTo($"In the {bag.Name}, you can see:\n{fd}"));
            Assert.That(bag.Inventory.ItemList.Count, Is.EqualTo(3));
        }

        [Test]
        public void TestBagInBag()
        {
            Bag b1 = new Bag(new string[] { "duffle bag", "grey duffle bag" }, "my duffle bag", "A large grey dufflebag");
            Bag b2 = new Bag(new string[] { "rucksack", "a grey rucksack" }, "my rucksack", "A grey rucksack");
            Item potion = new Item(new string[] { "potion", "health potion" }, "my potion", "A small health potion.");

            b1.Inventory.Put(b2);
            b1.Inventory.Put(potion);

            GameObject item1 = b1.Locate("rucksack");
            GameObject item2 = b1.Locate("potion");
            GameObject item3 = b2.Locate("potion");

            Assert.That(item1.AreYou("rucksack"), Is.True);
            Assert.That(item2.AreYou("potion"), Is.True);
            Assert.That(item3, Is.Null);
        }

    }
}
