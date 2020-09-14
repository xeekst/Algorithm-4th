using System;
using System.Linq;

namespace Ex_1._1._21
{
    class Program
    {
        /// <summary>
        /// 1.1.21
        /// </summary>
        /// <param name="key"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        static int Rank(int key, int[] a)
        {
            return Rank(key, a, 0, a.Length - 1, 1);
        }
        static int Rank(int key, int[] a, int lo, int hi, int invokeHigh)
        {
            Console.WriteLine($"invoke:{invokeHigh},lo:{lo},hi:{hi}");
            if (lo > hi) return -1;
            int mid = a[lo + (hi - lo) / 2];
            if (key < a[mid]) return Rank(key, a, lo, mid - 1, ++invokeHigh);
            else if (key > a[mid]) return Rank(key, a, mid + 1, hi, ++invokeHigh);
            else return mid;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Rank(567, Enumerable.Range(0, 100000).ToArray()));
        }
    }
}
