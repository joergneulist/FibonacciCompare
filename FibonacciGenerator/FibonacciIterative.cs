namespace FibonacciGenerator
{
    public class FibonacciIterative : Fibonacci
    {
        protected override int GetValue(int key)
        {
            int current = 0;
            int next = 1;
            for (int index = 0; index < key; index++)
                (current, next) = (next, current + next);

            return current;
        }
    }
}
