using System;
using System.Collections;
using System.Collections.Generic;

namespace FibonacciGenerator
{
    public abstract class Fibonacci : IEnumerable<int>
    {
        public enum Algorithm { Cached, Direct, Iterative, IterativeYield, Recursive };
        public static Fibonacci Factory(Algorithm algorithm)
        {
            switch (algorithm)
            {
                case Algorithm.Cached:
                    return new FibonacciCached();

                case Algorithm.Direct:
                    return new FibonacciCached();

                case Algorithm.Iterative:
                    return new FibonacciIterative();

                case Algorithm.IterativeYield:
                    return new FibonacciYield();

                case Algorithm.Recursive:
                    return new FibonacciRecursive();

                default:
                    throw new NotImplementedException();
            }
        }

        public int this[int key]
        {
            get => GetValue(key);
            private set { }
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
            => GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetValues().GetEnumerator();

        protected abstract int GetValue(int key);

        protected virtual IEnumerable<int> GetValues()
        {
            int key = 0;
            while (true)
                yield return GetValue(key++);
        }
    }
}
