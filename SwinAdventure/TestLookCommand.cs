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
        public void TestLookAtMe()
        {

            //Assert.That(bag.FullDescription, Is.EqualTo($"In the {bag.Name}, you can see:\n{itemsDescription}"));
            //Assert.That(bag.Inventory.ItemList.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestLookAtGem()
        {

            //Assert.That(b1.Name, Is.EqualTo("my bag"));
            //Assert.That(b2.Name, Is.EqualTo("my bag"));
        }

        [Test]
        public void TestLookAtUnk()
        {

            //Assert.That(b, Is.Null);
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            //Assert.That(bag.FullDescription, Is.EqualTo($"In the {bag.Name}, you can see:\n{fd}"));
            //Assert.That(bag.Inventory.ItemList.Count, Is.EqualTo(3));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            //Assert.That(item1.AreYou("rucksack"), Is.True);
            //Assert.That(item2.AreYou("potion"), Is.True);
            //Assert.That(item3, Is.Null);
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            //Assert.That(item1.AreYou("rucksack"), Is.True);
            //Assert.That(item2.AreYou("potion"), Is.True);
            //Assert.That(item3, Is.Null);
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            //Assert.That(item1.AreYou("rucksack"), Is.True);
            //Assert.That(item2.AreYou("potion"), Is.True);
            //Assert.That(item3, Is.Null);
        }

        [Test]
        public void TestInvalidLook()
        {
            //Assert.That(item1.AreYou("rucksack"), Is.True);
            //Assert.That(item2.AreYou("potion"), Is.True);
            //Assert.That(item3, Is.Null);
        }
    }
}
