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
    public class TestPlayer
    {
        // arrange
        Player player;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Aaron", "A mighty programmer");
        }

        // act and assert
        [Test]
        public void TestPlayerIsIdentifiable()
        {
            bool result1 = player.AreYou("me");
            bool result2 = player.AreYou("inventory");
            Assert.That(result1 && result2, Is.True);
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            player.Inventory.Put(shovel);
            GameObject item = player.Locate("shovel");

            Assert.That(item.ShortDescription, Is.EqualTo("a shovel (shovel)"));
            Assert.That(player.Inventory.ItemList.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            GameObject p1 = player.Locate("me");
            GameObject p2 = player.Locate("inventory");

            Assert.That(p1.Name, Is.EqualTo("Aaron"));
            Assert.That(p2.Name, Is.EqualTo("Aaron"));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            GameObject p = player.Locate("gem");

            Assert.That(p, Is.Null);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item sword = new Item(new string[] { "sword", "short sword" }, "a bronze sword", "This is a mighty fine sword");
            Item computer = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a mighty fine computer");

            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            player.Inventory.Put(computer);

            string fd = player.FullDescription;
            Assert.That(fd, Is.EqualTo("You are carrying:\n" +
                "\ta shovel (shovel)\n" +
                "\ta bronze sword (sword)\n" +
                "\ta small computer (pc)"
                ));
            Assert.That(player.Inventory.ItemList.Count, Is.EqualTo(3));
        }

    }
}
