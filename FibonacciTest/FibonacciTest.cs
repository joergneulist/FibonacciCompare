using Microsoft.VisualStudio.TestTools.UnitTesting;
using FibonacciGenerator;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciTest
{
    [TestClass]
    public class FibonacciTest
    {
        private Fibonacci fib;
        [TestInitialize]
        public void Setup()
        {
            fib = new FibonacciRecursive();
        }

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
            var list = fib.Take(10);

            CollectionAssert.AreEqual(trueList, list.ToList());
        }
    }
}
