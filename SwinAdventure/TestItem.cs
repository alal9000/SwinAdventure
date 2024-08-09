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
    public class TestItem
    {
        // arrange
        private Item _item;

        [SetUp]
        public void SetUp()
        {
            _item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
        }

        // act and assert
        [Test]
        public void TestItemIsIdentifiable()
        {
            bool result = _item.AreYou("shovel");
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestShortDescription()
        {
            string result = _item.ShortDescription;
            Assert.That(result, Is.EqualTo("a shovel (shovel)"));
        }

        [Test]
        public void TestFullDescription()
        {
            string result = _item.FullDescription;
            Assert.That(result, Is.EqualTo("This is a mighty fine shovel"));
        }

    }
}
