using Academy.Models.Abstractions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests
{
    [TestFixture]
    class TestAcademyUser
    {
        [TestCase ("d")]
        [TestCase("efjsopaplswsoriufjeodkawpoergtiroeporiedrfgytr")]
        [TestCase(null)]
        public void TestUserUsername_ShouldThrowAnException_WhenInputIsntCorrect(string name)
        {
            Assert.Throws<ArgumentException>(() => new FakeUser(name));
        }

        [Test]
        public void TestUserUsername_ShouldntThrowAnException_WhenInputIsCorrect()
        {
            Assert.DoesNotThrow(() => new FakeUser("Yoana"));
        }

        [Test]
        public void TestUsername_ShouldAssignUsername_WhenInputIsCorrect()
        {
            var user = new FakeUser("Yoana");
            Assert.AreEqual("Yoana", user.Username);
        }

    }

    class FakeUser : User
    {
        public FakeUser(string username) : base(username)
        {
        }

    }
}
