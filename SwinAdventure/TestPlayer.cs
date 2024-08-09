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
        private IdentifiableObject _identifiableObject;

        [SetUp]
        public void SetUp()
        {
            string[] test = { "fred", "bob" };
            _identifiableObject = new IdentifiableObject(test);
        }

        // act and assert
        [Test]
        public void TestAreYou()
        {
            bool result = _identifiableObject.AreYou("fred");
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestNotAreYou()
        {
            bool result1 = _identifiableObject.AreYou("wilma");
            bool result2 = _identifiableObject.AreYou("boby");
            Assert.That(result1 && result2, Is.False);
        }

        [Test]
        public void TestCaseSensitive()
        {
            bool result1 = _identifiableObject.AreYou("FRED");
            bool result2 = _identifiableObject.AreYou("bOB");

            Assert.That(result1 && result2, Is.True);
        }

        [Test]
        public void TestFirstID()
        {
            string result = _identifiableObject.FirstId;

            Assert.That(result, Is.EqualTo("fred"));
        }

        [Test]
        public void TestAddID()
        {
            _identifiableObject.AddIdentifier("wilma");

            bool result1 = _identifiableObject.AreYou("wilma");
            bool result2 = _identifiableObject.AreYou("fred");
            bool result3 = _identifiableObject.AreYou("bob");

            Assert.That(result1 && result2 && result3, Is.True);
        }

    }
}
