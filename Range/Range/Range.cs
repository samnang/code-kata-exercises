using System;

namespace Range.Tests
{
    public class Range
    {
        public Range(int start, int end)
        {
            if (IsRangeInValid(start, end))
                throw new ArgumentException();

            Start = start;
            End = end;
        }

        public int Start { get; private set; }

        public int End { get; private set; }

        public bool Include(int number)
        {
            return number >= Start && number <= End;
        }

        public Range Intersect(Range range)
        {
            int start = Math.Max(Start, range.Start);
            int end = Math.Min(End, range.End);

            if (IsRangeInValid(start, end))
                throw new ArgumentException();

            return new Range(start, end);
        }

        private bool IsRangeInValid(int start, int end)
        {
            return end < start;
        }

        public void Step(Action<int> action)
        {
            for (int begin = Start; begin <= End; begin++)
            {
                action(begin);
            }
        }
    }
}