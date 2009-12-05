using System;
using NUnit.Framework;

namespace StringCalculator.Tests {
    [TestFixture]
    public class StringCalculatorTests {
        private StringCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator();
        }

        [Test]
        public void Sum_EmptyString_Zero()
        {
            var expectedResult = 0;

            var result = _calculator.Sum(string.Empty);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Sum_Null_Zero()
        {
            var expectedResult = 0;

            int result = _calculator.Sum(null);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, "1")]
        [TestCase(3, "3")]
        public void Sum_OneNumber_Number(int expectedResult, string numbers)
        {
            var result = _calculator.Sum(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(5, "2,3")]
        [TestCase(10, "5,3,2")]
        public void Sum_MulipleNumbers_TotalOfNumbers(int expectedResult, string numbers)
        {
            var result = _calculator.Sum(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Sum_MultipleNumbersWithSpace_TotalOfNumbers()
        {
            var expectedResult = 5;

            int result = _calculator.Sum("2, 3");

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Sum_MultipleNumbersWithNewLine_TotalOfNumbers()
        {
            var expectedResult = 6;

            int result = _calculator.Sum("1\n2,3");

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1\n")]
        [TestCase("1\n,2,")]
        public void Sum_HasDelimiterWithNoNumbers_InvalidNumbers(string numbers)
        {
            Assert.Throws<ArgumentException>(() => _calculator.Sum(numbers));
        }

        [TestCase(9, "//;\n2;3;4")]
        [TestCase(2, "//.\n2")]
        [TestCase(3, "//@\n1@2")]
        public void Sum_NumbersWithCustomDelimiter_TotalOfNumbers(int expectedResult, string numbers)
        {
            int result = _calculator.Sum(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Sum_NegativeNumber_InvalidNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Sum("-1"));
        }

        [Test]
        public void Sum_NegativeMultipleNumbers_DisplaysNegativeNumbers()
        {
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Sum("-1,2,-3"));

            Assert.That(error.Message, Is.StringContaining("-1,-3"));
        }
    }
}
