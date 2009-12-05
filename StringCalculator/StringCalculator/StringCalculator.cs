using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Tests
{
    public class StringCalculator
    {
        private string _delimiters = ",\n";

        public int Sum(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            if (Regex.IsMatch(numbers, "//.\n"))
            {
                _delimiters += numbers[2];
                numbers = numbers.Substring(4, numbers.Length - 4);
            }


            return numbers.Split(_delimiters.ToCharArray()).Sum(number =>
                                                                    {
                                                                        if (number == string.Empty)
                                                                            throw new ArgumentException(
                                                                                "Invalid numbers: {0}", numbers);

                                                                        return int.Parse(number);
                                                                    });
        }
    }
}