using FibonacciGenerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FibonacciCompare
{
    class Compare
    {
        private class Test
        {
            public delegate int TestCase(Fibonacci calculator);

            private TestCase code;
            private int repetitions;
            public string Name { get; set; }

            public Test(TestCase testCode, int testRepetitions, string name)
            {
                code = testCode;
                repetitions = testRepetitions;
                Name = name;
            }

            public double TimeExecution(Fibonacci calculator)
            {
                var watch = Stopwatch.StartNew();
                for (var i = 0; i < repetitions; i++)
                    code(calculator);
                watch.Stop();
                return watch.ElapsedMilliseconds * 1000.0 / (double)repetitions;
            }
        }



        static void Main(string[] args)
        {
            var testList = new List<Test> {
                new Test(f =>  f[0], 1000000, "Fib[0]"),
                new Test(f =>  f[5], 1000000, "Fib[5]"),
                new Test(f => f[10], 1000000, "Fib[10]"),
                new Test(f => f[10], 1000000, "Fib[20]"),
                new Test(f => f.Take(10).Sum(), 10, "List 10"),
                new Test(f => f.Take(40).Sum(), 10, "List 40")
            };

            Console.WriteLine("{0,20} | {1}", "Algorithm", string.Join(" | ", testList.Select(test => string.Format("{0,10}", test.Name))));


            foreach (var algorithm in Enum.GetValues(typeof(Fibonacci.Algorithm)).Cast<Fibonacci.Algorithm>())
            {
                var fib = Fibonacci.Factory(algorithm);
                Console.WriteLine("{0,20} | {1}",
                    algorithm.ToString(),
                    string.Join(" | ", testList.Select(test => string.Format("{0,10:N5}", test.TimeExecution(fib)))));
            }
        }
    }
}
