using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace StringCalculator.Tests {
    [TestFixture]
    public class StringCalculatorTests {
        private StringCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new StringCalculator();
        }

        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            int result = _calculator.Add(string.Empty);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_OneNumber_ReturnTheNumber()
        {
            int result = _calculator.Add("2");

            Assert.AreEqual(2, result);
        }

        [TestCase("2,3", 5)]
        [TestCase("10,20", 30)]
        public void Add_TwoNumbers_ReturnSumOfNumbers(string numbers, int expectedResult)
        {
            int result = _calculator.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Add_MultipleNumbers_ReturnSumOfNumbers()
        {
            int result = _calculator.Add("2,3,5");

            Assert.AreEqual(10, result);
        }

        [TestCase("2\n3", 5)]
        [TestCase("10\n20", 30)]
        public void Add_MultipleNumbersWithNewLineDelimiter_ReturnSumOfNumbers(string numbers, int expectedResult)
        {
            int result = _calculator.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Add_HasDelimiterWithNoNumber_ErrorInvalidNumber()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Add("2,"));
        }

        [TestCase("//;\n2;3", 5)]
        [TestCase("//?\n10?20?30", 60)]
        public void Add_MultipleNumbersWithCustomDelimiter_ReturnSumOfNumbers(string numbers, int expectedResult)
        {
            int result = _calculator.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Add_NegativeNumber_ErrorInvalidNumber()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Add("2,-3"));
        }

        [Test]
        public void Add_NegativeNumbers_ErrorMessageContainsAllNegativeNumbers()
        {
            var error = Assert.Throws<ArgumentException>(() => _calculator.Add("-2,3,-10,5"));

            Assert.IsTrue(error.Message.Contains("-2,-10"));
        }
    }
}
