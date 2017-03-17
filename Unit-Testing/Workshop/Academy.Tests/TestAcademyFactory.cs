using Academy.Core.Factories;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests
{
    [TestFixture]
    class TestAcademyFactory
    {
        [Test]
        public void ReturnVideoResourse_WhenVideoTypeIsPassed()
        {
            var factory = AcademyFactory.Instance;

            var resourse = factory.CreateLectureResource("video", "Pesho's video", "111111");

            Assert.IsInstanceOf(typeof(VideoResource), resourse);
        }

        [Test]
        public void ReturnDemoResourse_WhenDemoTypeIsPassed()
        {
            var factory = AcademyFactory.Instance;

            var resourse = factory.CreateLectureResource("demo", "Pesho's video", "111111");

            Assert.IsInstanceOf(typeof(DemoResource), resourse);
        }

        [Test]
        public void ThrowArgumentException_WhenInvalidResourceTypeIsPassed()
        {
            var factory = AcademyFactory.Instance;

            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("pesho", "Pesho's video", "111111"));
        }
    }
}
