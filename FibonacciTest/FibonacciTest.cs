using FibonacciGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestBase
{
    [TestClass]
    public abstract class FibonacciTest
    {
        protected Fibonacci fib;

        [TestInitialize]
        public abstract void Setup();

        [TestMethod]
        public void TestFibonacciStart()
        {
            Assert.AreEqual(0, fib[0]);
            Assert.AreEqual(1, fib[1]);
        }

        [TestMethod]
        public void TestFibonacciBig()
        {
            Assert.AreEqual(102334155, fib[40]);
        }

        [TestMethod]
        public void TestFibonacciList()
        {
            var trueList = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            var list = fib.Enumerate(10);

            CollectionAssert.AreEqual(trueList, list.ToList());
        }
    }

    [TestClass]
    public class TestCached : FibonacciTest
    {
        [TestInitialize]
        public override void Setup()
        {
            fib = Fibonacci.Factory(Fibonacci.Algorithm.Cached);
        }
    }

    [TestClass]
    public class TestDirect : FibonacciTest
    {
        [TestInitialize]
        public override void Setup()
        {
            fib = Fibonacci.Factory(Fibonacci.Algorithm.Direct);
        }
    }

    [TestClass]
    public class TestIterative : FibonacciTest
    {
        [TestInitialize]
        public override void Setup()
        {
            fib = Fibonacci.Factory(Fibonacci.Algorithm.Iterative);
        }
    }

    [TestClass]
    public class TestYield : FibonacciTest
    {
        [TestInitialize]
        public override void Setup()
        {
            fib = Fibonacci.Factory(Fibonacci.Algorithm.IterativeYield);
        }
    }

    [TestClass]
    public class TestRecursive : FibonacciTest
    {
        [TestInitialize]
        public override void Setup()
        {
            fib = Fibonacci.Factory(Fibonacci.Algorithm.Recursive);
        }
    }
}
