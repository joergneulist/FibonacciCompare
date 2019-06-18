using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciGenerator
{
    public abstract class Fibonacci
    {
        public enum Algorithm { Cached, Direct, Iterative, IterativeYield, Recursive };
        public static Fibonacci Factory(Algorithm algorithm)
        {
            switch (algorithm)
            {
                case Algorithm.Cached:
                    return new FibonacciCached();

                case Algorithm.Direct:
                    return new FibonacciDirect();

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

        public virtual IEnumerable<int> Enumerate(int listLength)
        {
            return Enumerable.Range(0, listLength).Select(key => GetValue(key));
        }

        protected abstract int GetValue(int key);
    }
}
