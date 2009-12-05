using System.Linq;

namespace StringCalculator.Tests
{
    public class StringCalculator
    {
        public int Sum(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            if (IsMultipleNumbers(numbers))
            {
                return numbers.Split(',').Sum(number => int.Parse(number));
            }

            return int.Parse(numbers);
        }

        private bool IsMultipleNumbers(string numbers)
        {
            return numbers.Contains(",");
        }
    }
}