using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class CachingServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowException_WhenDateTimeProviderIsNull()
        {
            TimeSpan duration = new TimeSpan(20);

            Assert.Throws<ArgumentNullException>(() => new CachingServiceFake(duration, null));
        }

        [Test]
        public void Constructor_ShouldCreateInstance_WhenParametersAreCorrect()
        {
            TimeSpan duration = new TimeSpan(20);
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var service = new CachingServiceFake(duration, mockedDateTimeProvider.Object);
            Assert.IsInstanceOf<CachingService>(service);
        }

        [Test]
        public void ResetCache_ShouldMakeCacheNewDictionary()
        {
            TimeSpan duration = new TimeSpan(20);
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var service = new CachingServiceFake(duration, mockedDateTimeProvider.Object);
            service.Cache.Add(new KeyValuePair<string, object>("cache", "other"));
            service.ResetCache();
            Assert.AreNotEqual(service.Cache.Count, 1);
        }
    }
}
