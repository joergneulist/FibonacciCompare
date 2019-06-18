using System.Collections.Generic;
using System.Linq;

namespace FibonacciGenerator
{
    public class FibonacciYield : Fibonacci
    {
        protected override int GetValue(int key)
            => Enumerate(key + 1).Last();

        public override IEnumerable<int> Enumerate(int listLength)
        {
            int current = 0;
            int next = 1;

            for (int key = 0; key < listLength; key++)
            {
                yield return current;
                (current, next) = (next, current + next);
            }
        }
    }
}
