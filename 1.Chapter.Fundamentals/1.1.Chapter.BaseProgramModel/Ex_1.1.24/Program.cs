using System;

namespace Ex_1._1._24
{
    class Program
    {
        /// <summary>
        /// 1.1.24 辗转相除法求最大公约数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static uint Gcd(uint a, uint b)
        {
            uint min = a;
            uint max = b;
            if (a > b)
            {
                min = b;
                max = a;
            }
            else if (b > a)
            {
                max = b;
                min = a;
            }
            else return a;

            uint m = max % min;
            if (m == 0) return min;
            else return Gcd(min, m);
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Gcd:{Gcd(1234, 9124156)}");
        }
    }
}
