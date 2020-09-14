using System;
using System.Collections.Generic;

namespace Ex_1._1._15
{
    class Program
    {
        /// <summary>
        /// 1.1.15
        /// </summary>
        /// <param name="a"></param>
        /// <param name="M"></param>
        static void Histogram(int[] a, int M)
        {
            int[] am = new int[M];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < M) am[a[i]]++;
            }
            Util.ShowArray(am);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("====================================");
            Histogram(new List<int>() { 1, 3, 4, 5, 6, 3 }.ToArray(), 4);
        }
    }
}
