using System;
using NUnit.Framework;

namespace Range.Tests
{
    [TestFixture]
    public class RangeTests
    {
        private Range CreateRange(int start, int end)
        {
            return new Range(start, end);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Include_NumberInRange_ReturnTrue(int number)
        {
            var range = CreateRange(1, 5);

            AssertNumberInRange(range, number, true);
        }

        [TestCase(10)]
        [TestCase(0)]
        public void Include_NumberNotInRange_ReturnFalse(int numberNotInRange)
        {
            var range = CreateRange(1, 5);

            AssertNumberInRange(range, numberNotInRange, false);
        }

        [Test]
        public void Constructor_ValidRange_StartAndEndSetCorrectly()
        {
            var range = CreateRange(1, 5);

            Assert.AreEqual(1, range.Start);
            Assert.AreEqual(5, range.End);
        }

        [Test]
        public void Constructor_InValidRange_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => CreateRange(2, 1));
        }

        [Test]
        public void Intersect_TwoRanges_ReturnNewRangeResult()
        {
            var range1 = CreateRange(1, 5);
            var range2 = CreateRange(2, 7);

            Range result = range1.Intersect(range2);

            Assert.AreEqual(2, result.Start);
            Assert.AreEqual(5, result.End);
        }

        [Test]
        public void Intersect_TwoRangesNotHasIntersectedRange_ThrowException()
        {
            var range1 = CreateRange(1, 5);
            var range2 = CreateRange(6, 10);

            Assert.Throws<ArgumentException>(() => range1.Intersect(range2));
        }

        [Test]
        public void Step_PassingDelegate_ProcessAllSteps()
        {
            var range = CreateRange(1, 5);
            var calledCount = 0;
            range.Step((number) => calledCount += 1);

            Assert.AreEqual(5, calledCount);
        }

        private void AssertNumberInRange(Range range, int number, bool expectedResult)
        {
            
            var result = range.Include(number);

            Assert.AreEqual(expectedResult, result);
        }
    }
}