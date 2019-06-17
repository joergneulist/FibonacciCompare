using System;
using System.Collections;
using System.Collections.Generic;

namespace FibonacciGenerator
{
    public abstract class Fibonacci : IEnumerable<int>
    {
        public enum Algorithm { Recursive };
        public static Fibonacci Factory(Algorithm algorithm)
        {
            switch (algorithm)
            {
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

        protected abstract IEnumerable<int> GetValues();
    }
}
