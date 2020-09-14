using System;

namespace Ex_1._1._16
{
    class Program
    {
        /// <summary>
        /// 1.1.16
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static string exR1(int n)
        {
            if (n <= 0) return "";
            return exR1(n - 3) + n + exR1(n - 2) + n;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(exR1(6));
        }
    }
}
