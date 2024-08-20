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
    public class TestBag
    {
        // arrange
        Bag bag;

        [SetUp]
        public void SetUp()
        {
            bag = new Bag(new string[] { "bag", "leather bag" }, "a bag", "A black leather bag");
        }

        // act and assert
        [Test]
        public void TestBagLocatesItems()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item pc = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a mighty fine computer");
            bag.Inventory.Put(shovel);
            bag.Inventory.Put(pc);
            GameObject i1 = bag.Locate("shovel");
            GameObject i2 = bag.Locate("pc");

            Assert.That(i1.ShortDescription, Is.EqualTo("a shovel (shovel)"));
            Assert.That(i2.ShortDescription, Is.EqualTo("a small computer (pc)"));
            Assert.That(bag.FullDescription, Is.EqualTo("In the " + bag.Name + "you can see" + bag.Inventory.ItemList));
            Assert.That(bag.Inventory.ItemList.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestBagLocatesItself()
        {
            GameObject b1 = bag.Locate("bag");
            GameObject b2 = bag.Locate("leather bag");

            Assert.That(b1.Name, Is.EqualTo("bag"));
            Assert.That(b2.Name, Is.EqualTo("bag"));
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

            string fd = bag.FullDescription;
            Assert.That(fd, Is.EqualTo("In the " + bag.Name + "you can see" +
                bag.Inventory.ItemList
                ));
            Assert.That(bag.Inventory.ItemList.Count, Is.EqualTo(3));
        }

        [Test]
        public void TestBagInBag()
        {
            Bag b1 = new Bag(new string[] { "duffle bag", "grey duffle bag" }, "a duffle bag", "A large grey dufflebag");
            Bag b2 = new Bag(new string[] { "backpack", "a blue backpack" }, "a backpack", "A blue Jansport backpack");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");

            b1.Inventory.Put(b2);
            b1.Inventory.Put(shovel);
            GameObject item1 = b1.Locate("backpack"); 
            GameObject item2 = b1.Locate("shovel");

            //Assert.That(item1.AreYou("backpack"), Is.True);
            Assert.That(item1.AreYou("backpack"), Is.True);
            Assert.That(item2.AreYou("shovel"), Is.True);
        }

    }
}
