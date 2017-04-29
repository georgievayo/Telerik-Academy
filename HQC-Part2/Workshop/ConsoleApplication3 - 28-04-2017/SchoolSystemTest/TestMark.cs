using System;
using NUnit.Framework;
using SchoolSystem;

namespace SchoolSystemTest
{
    [TestFixture]
    public class TestMark
    {
        [Test]
        public void TestMarkConstructor_WhenPassedArgumentsAreCorrect_ShouldCreateNewInstance()
        {
            var subject = Subject.Math;
            var markValue = 3;

            var mark = new Mark(subject, markValue);
            Assert.IsInstanceOf<Mark>(mark);
        }

        [Test]
        public void TestMarkSubjectProperty_WhenPassedArgumentIsCorrect_ShouldSetSubject()
        {
            var subject = Subject.Math;
            var markValue = 3;
            var mark = new Mark(subject, markValue);
            Assert.AreEqual(subject, mark.Subject);
        }

        [Test]
        public void TestMarkSubjectProperty_WhenPassedArgumentIsNotCorrect_ShouldThrowArgumentException()
        {
            var subject = (Subject)10;
            var markValue = 3;
            Assert.Throws<ArgumentException>(() => new Mark(subject, markValue));
        }

        [Test]
        public void TestMarkValueProperty_WhenPassedArgumentIsCorrect_ShouldSetValue()
        {
            var subject = Subject.Math;
            var markValue = 3;
            var mark = new Mark(subject, markValue);
            Assert.AreEqual(markValue, mark.Value);
        }

        [Test]
        public void TestMarkValueProperty_WhenPassedArgumentIsNotCorrect_ShouldThrowArgumentException()
        {
            var subject = Subject.Math;
            var markValue = 0;
            Assert.Throws<ArgumentException>(() => new Mark(subject, markValue));
        }
    }
}
