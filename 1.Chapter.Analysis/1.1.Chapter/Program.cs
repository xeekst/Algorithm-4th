using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._1.Chapter
{
    class Program
    {
        static void _1_1_1()
        {
            var v1 = (0 + 15) / 2;
            var v2 = 2.0 * Math.E - 6 * 100000000.1;
            var v3 = true && false || true && true;
            Console.WriteLine($"v1:{v1},v2:{v2},v3:{v3}");
        }
        static void _1_1_2()
        {
            var v1 = (1 + 2.236) / 2;
            var v2 = 1 + 2 + 3 + 4.0;
            var v3 = 4.1 >= 4;

        }
        /// <summary>
        /// 1.1.13 数组转置
        /// </summary>
        /// <param name="array"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        static T[][] Transpose<T>(T[][] array)
        {
            if (array.Length < 1) return null;
            int len = array[0].Length;
            int high = array.Length;
            var newArray = new T[len][];
            for (int c = 0; c < len; c++)
            {
                newArray[c] = new T[high];
                for (int r = 0; r < high; r++)
                {
                    newArray[c][r] = array[r][c];
                }
            }
            ShowArray(newArray);
            return newArray;
        }

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
            ShowArray(am);
        }
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

        public static long Fibonacci(int N)
        {
            if (N == 0) return 0;
            if (N == 1) return 1;
            return Fibonacci(N - 2) + Fibonacci(N - 1);

        }
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
            _1_1_1();
            var array = new int[2][];
            array[0] = Enumerable.Range(1, 2).ToArray();
            array[1] = Enumerable.Range(32, 2).ToArray();

            array = Transpose<int>(array);
            Console.WriteLine("====================================");
            array = Transpose<int>(array);

            Console.WriteLine("====================================");
            Histogram(new List<int>() { 1, 3, 4, 5, 6, 3 }.ToArray(), 4);
            Console.WriteLine("====================================");
            Console.WriteLine(exR1(6));
            Console.WriteLine("====================================");
            Console.WriteLine(Fibonacci(10));

            Console.WriteLine("====================================");
            Console.WriteLine(Rank(567, Enumerable.Range(0, 100000).ToArray()));
            Console.WriteLine("end");
        }
        static void ShowArray<T>(T[][] array)
        {
            for (int r = 0; r < array.Length; r++)
            {
                for (int c = 0; c < array[r].Length; c++)
                {
                    Console.Write($"  {array[r][c]}");
                }
                Console.WriteLine();
            }
        }
        static void ShowArray<T>(T[] array)
        {
            for (int r = 0; r < array.Length; r++)
            {
                Console.Write($"  {array[r]}");
            }
            Console.WriteLine();
        }

    }
}
