using System.Collections.Generic;
using System.Linq;

namespace FibonacciGenerator
{
    public class FibonacciYield : Fibonacci
    {
        protected override int GetValue(int key)
            => GetValues().Skip(key).First();

        protected override IEnumerable<int> GetValues()
        {
            int current = 0;
            int next = 1;

            while (true)
            {
                yield return current;
                (current, next) = (next, current + next);
            }
        }
    }
}
