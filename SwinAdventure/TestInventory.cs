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
    public class TestInventory
    {
        // arrange
        Inventory _inventory;

        [SetUp]
        public void SetUp()
        {
           _inventory = new Inventory();
        }

        // act and assert
        [Test]
        public void TestFindItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            _inventory.Put(shovel);
            Item item = _inventory.Fetch("shovel");
            bool result = item.AreYou("gem");

            Assert.That(result, Is.False);


        }

        [Test]
        public void TestNoItemFind()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            _inventory.Put(shovel);
            Item item = _inventory.Fetch("shovel");
            bool result = item.AreYou("gem");

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestFetchItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            _inventory.Put(shovel);
            List<string> items = _inventory.ItemList;
            Item item = _inventory.Fetch("shovel");
            bool result = item.AreYou("shovel");

            Assert.That(result, Is.True);
            Assert.That(items.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestTakeItem()
        {

            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            _inventory.Put(shovel);
            Item item = _inventory.Take("shovel");
            bool result = item.AreYou("shovel");
            List<string> items = _inventory.ItemList;

            Assert.That(result, Is.True);
            Assert.That(items.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestItemList()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item gem = new Item(new string[] { "gem", "treasure" }, "a gem", "This is a mighty fine gem");
            _inventory.Put(shovel);
            _inventory.Put(gem);
            List<string> items = _inventory.ItemList;

            List<string> expectedItems = new List<string>()
            {
                "\ta shovel (shovel)", 
                "\ta gem (gem)"        
            };

            Assert.That(items, Is.EqualTo(expectedItems));
        }

    }
}
