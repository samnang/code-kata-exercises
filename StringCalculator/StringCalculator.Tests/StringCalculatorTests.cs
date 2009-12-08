using System;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator();
        }

        #endregion

        private StringCalculator _calculator;

        [TestCase("5", 5)]
        [TestCase("20", 20)]
        public void Add_OneNumber_ReturnTheNumber(string numbers, int expectedResult)
        {
            int result = _calculator.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("5,5", 10)]
        [TestCase("10,5", 15)]
        [TestCase("2, 3", 5)]
        public void Add_TwoNumber_ReturnSumOfNumbers(string numbers, int expectedResult)
        {
            int result = _calculator.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("2\n3", 5)]
        [TestCase("2\n10\n8", 20)]
        public void Add_MulitpleNumbersWithNewLineDelimiter_ReturnSumOfNumbers(string numbers, int expectedResult)
        {
            int result = _calculator.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("2,")]
        [TestCase(",3")]
        [TestCase("2,20,")]
        public void Add_HasDelimiterWithNoNumber_ErrorInvalidNumbers(string numbers)
        {
            Assert.Throws<ArgumentException>(() => _calculator.Add(numbers));
        }

        [TestCase("//;\n2;3", 5)]
        [TestCase("//.\n10.30", 40)]
        public void Add_MultipleNumberWithCustomDelimiter_ReturnSumOfNumbers(string numbers, int expectedResult)
        {
            int result = _calculator.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("-1,4,-5", "-1,-5")]
        [TestCase("1,-20,-5,20", "-20,-5")]
        public void Add_NegativeNumbers_DisplayNegativeNumbers(string numbers, string expectedResult)
        {
            var error = Assert.Throws<ArgumentException>(() => _calculator.Add(numbers));

            Assert.IsTrue(error.Message.Contains(expectedResult));
        }

        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            int expectedResult = 0;

            int result = _calculator.Add(string.Empty);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Add_NegativeNumbers_ErrorInvalidNumbers()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Add("2,-1"));
        }
    }
}