using System;

namespace AlgorithmCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Percolationer.PerUF.TestMain();
            string[] array = new string[2];
            Percolationer.Percolation.main(array);
        }
    }
}
