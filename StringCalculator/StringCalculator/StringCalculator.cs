using System;

namespace StringCalculator
{
    public class StringCalculator
    {
        private string _delimiters = ",\n";

        public int Add(string numbers)
        {
            if(string.IsNullOrEmpty(numbers))
                return 0;

            if(IsCustomDelimiter(numbers))
            {
                _delimiters += numbers[2];
                numbers = GetNumbersForCustomDelimiter(numbers);
            }

            int sumOfNumbers = 0;
            string negativeNumbers = string.Empty;

            var items = numbers.Split(_delimiters.ToCharArray());
            foreach (var number in items)
            {
                if (string.IsNullOrEmpty(number))
                    throw new ArgumentException();

                if (int.Parse(number) < 0)
                    negativeNumbers += string.Format("{0},", number);

                sumOfNumbers += int.Parse(number);
            }

            if(!string.IsNullOrEmpty(negativeNumbers))
                throw new ArgumentException(string.Format("Negatives are not allow: \n{0}",
                                                          negativeNumbers.Substring(0, negativeNumbers.Length - 1)));

            return sumOfNumbers;
        }

        private string GetNumbersForCustomDelimiter(string numbers)
        {
            return numbers.Substring(4, numbers.Length - 4);;
        }

        private bool IsCustomDelimiter(string numbers)
        {
            return numbers.Contains("//");
        }
    }
}