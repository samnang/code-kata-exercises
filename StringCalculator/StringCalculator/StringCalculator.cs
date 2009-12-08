using System;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            string delimiters = ",\n";

            if (numbers == string.Empty)
                return 0;

            if (numbers.Contains("//"))
            {
                delimiters += numbers[2];
                numbers = numbers.Substring(4, numbers.Length - 4);
            }

            int sum = 0;
            string negativeNumbers = string.Empty;
            string[] items = numbers.Split(delimiters.ToCharArray());

            foreach (string number in items)
            {
                if (number == string.Empty)
                    throw new ArgumentException();

                if (int.Parse(number) < 0)
                    negativeNumbers += string.Format("{0},", number);

                sum += int.Parse(number);
            }

            if (negativeNumbers != string.Empty)
                throw new ArgumentException(negativeNumbers.Substring(0, negativeNumbers.Length - 1));

            return sum;
        }
    }
}