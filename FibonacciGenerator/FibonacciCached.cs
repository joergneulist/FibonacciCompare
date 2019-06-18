using System.Collections.Generic;
using System.Linq;

namespace FibonacciGenerator
{
    public class FibonacciCached : Fibonacci
    {
        private List<int> cache = new List<int> { 0, 1 };

        private void ExtendCache()
            => cache.Add(cache[cache.Count - 1] + cache[cache.Count - 2]);

        protected override int GetValue(int key)
        {
            while (key >= cache.Count)
                ExtendCache();
            return cache[key];
        }

        protected override IEnumerable<int> GetValues()
        {
            foreach (int value in cache)
                yield return value;

            while (true)
            {
                ExtendCache();
                yield return cache.Last();
            }
        }
    }
}
