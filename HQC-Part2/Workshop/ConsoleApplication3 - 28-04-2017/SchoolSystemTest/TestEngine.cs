using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SchoolSystem.Core;
using SchoolSystem.Models;

namespace SchoolSystemTest
{
    [TestFixture]
    class TestEngine
    {
        [Test]
        public void TestEngineConstructor_WhenCorrectParametersArePassed_ShouldCreateInstance()
        {
            var readerMock = new Mock<IReader>();
            var engine = new Engine(readerMock.Object);
            Assert.IsInstanceOf<Engine>(engine);
        }

        [Test]
        public void TestEngineStartMethod_ShouldExecuteCommand()
        {
            
        }
    }
}
