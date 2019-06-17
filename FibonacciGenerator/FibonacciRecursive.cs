using System.Collections.Generic;

namespace FibonacciGenerator
{
    public class FibonacciRecursive : Fibonacci
    {
        protected override int GetValue(int key)
            => (key < 2) ? key : GetValue(key - 1) + GetValue(key - 2);

        protected override IEnumerable<int> GetValues()
        {
            int key = 0;
            while (true)
                yield return GetValue(key++);
        }
    }
}
