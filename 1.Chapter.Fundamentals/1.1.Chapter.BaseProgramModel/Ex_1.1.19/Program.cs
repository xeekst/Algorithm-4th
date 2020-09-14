using System;

namespace Ex_1._1._19
{
    class Program
    {
        public static long Fibonacci(int N)
        {
            if (N == 0) return 0;
            if (N == 1) return 1;
            return Fibonacci(N - 2) + Fibonacci(N - 1);

        }
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci(10));
        }
    }
}
