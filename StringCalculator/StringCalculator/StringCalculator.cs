using System;
using System.Text.RegularExpressions;

namespace StringCalculator
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

            string[] items = numbers.Split(_delimiters.ToCharArray());
            string negativeNumbers = string.Empty;
            int totalNumbers = 0;

            foreach (string number in items)
            {
                if (number == string.Empty)
                    throw new ArgumentException(
                        "Invalid numbers: {0}", numbers);

                if (int.Parse(number) < 0)
                    negativeNumbers += string.Format("{0},", number);

                totalNumbers += int.Parse(number);
            }

            if (!string.IsNullOrEmpty(negativeNumbers))
                throw new ArgumentOutOfRangeException("negatives not allowed: {0}",
                                                      negativeNumbers.Substring(0, negativeNumbers.Length - 1));


            return totalNumbers;
        }
    }
}