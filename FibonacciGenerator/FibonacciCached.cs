using System.Collections.Generic;
using System.Linq;

namespace FibonacciGenerator
{
    public class FibonacciCached : Fibonacci
    {
        private List<int> cache = new List<int> { 0, 1 };

        private void ExtendCache(int highestNeeded)
        {
            while (cache.Count <= highestNeeded)
                cache.Add(cache[cache.Count - 1] + cache[cache.Count - 2]);
        }

        protected override int GetValue(int key)
        {
            ExtendCache(key);
            return cache[key];
        }

        public override IEnumerable<int> Enumerate(int listLength)
        {
            ExtendCache(listLength - 1);
            return cache.Take(listLength);
        }
    }
}
