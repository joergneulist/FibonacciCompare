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
            public string Name { get; set; }

            public Test(TestCase testCode, string name)
            {
                code = testCode;
                Name = name;
            }

            public double TimeExecution(Fibonacci calculator)
            {
                int repetitions = 0;
                var watch = Stopwatch.StartNew();

                while ((watch.ElapsedMilliseconds < 1000) || (repetitions < 3))
                {
                    code(calculator);
                    repetitions++;
                }
                watch.Stop();
                return watch.ElapsedMilliseconds * 1000.0 / (double)repetitions;
            }
        }

        static void Main(string[] args)
        {
            var testList = new List<Test> {
                new Test(f => f.Enumerate(10).Last(), "List 10"),
                new Test(f => f.Enumerate(20).Last(), "List 20"),
                new Test(f => f[0], "Fib[0]"),
                new Test(f => f[5], "Fib[5]"),
                new Test(f => f[10], "Fib[10]"),
                new Test(f => f[20], "Fib[20]"),
                new Test(f => f[40], "Fib[40]")
            };

            Console.WriteLine("{0,20} | {1}", "Algorithm", string.Join(" | ", testList.Select(test => string.Format("{0,10}", test.Name))));
            Console.WriteLine(new string('-', 21) + "+-" + string.Join("-+-", testList.Select(test => new string('-', 10))));

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
