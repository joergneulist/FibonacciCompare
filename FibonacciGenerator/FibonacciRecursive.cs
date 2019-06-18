namespace FibonacciGenerator
{
    public class FibonacciRecursive : Fibonacci
    {
        protected override int GetValue(int key)
            => (key < 2) ? key : GetValue(key - 1) + GetValue(key - 2);
    }
}
