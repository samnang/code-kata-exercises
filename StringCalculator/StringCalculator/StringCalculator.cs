using System;
using System.Linq;

namespace StringCalculator.Tests
{
    public class StringCalculator
    {
        private char[] _delimiters = new char[] {',', '\n'};

        public int Sum(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            if (IsMultipleNumbers(numbers))
            {
                return numbers.Split(_delimiters).Sum(number =>
                                                         {
                                                             if(number == string.Empty)
                                                                 throw new ArgumentException("Invalid numbers: {0}", numbers);

                                                             return int.Parse(number);
                                                         });
            }

            return int.Parse(numbers);
        }

        private bool IsMultipleNumbers(string numbers)
        {
            return numbers.Contains(_delimiters[0]) || numbers.Contains(_delimiters[1]);
        }
    }
}