using System;

namespace FibonacciGenerator
{
    public class FibonacciDirect : Fibonacci
    {
        // Moivre-Binet:
        // f_n = (phi^n - psi^n) / (phi - psi), where
        // phi = (1 + sqrt(5)) / 2
        // psi = 1 - phi
        // The formulation here is optimised for repeated execution:
        private static readonly double sqrt5 = Math.Sqrt(5);
        private static readonly double phi = 0.5 * (1.0 + sqrt5);
        private static readonly double psi = 0.5 * (1.0 - sqrt5);
        private static readonly double factor = 1.0 / sqrt5;

        protected override int GetValue(int key)
        {
            return (int) Math.Round((Math.Pow(phi, key) - Math.Pow(psi, key)) * factor);
        }
    }
}
