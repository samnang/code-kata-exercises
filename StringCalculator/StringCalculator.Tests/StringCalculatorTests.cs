﻿using System.Diagnostics;
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
    }
}