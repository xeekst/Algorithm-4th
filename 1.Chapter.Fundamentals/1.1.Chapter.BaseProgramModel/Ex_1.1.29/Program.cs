using System;
using System.Collections.Generic;

namespace Ex_1._1._29
{
    class Program
    {
        static int rank(int key, int[] array)
        {
            int lo = 0;
            int hi = array.Length - 1;
            return rank(key, lo, hi, array);
        }
        static int rank(int key, int lo, int hi, int[] array)
        {
            if (lo > hi) return -1;
            int m = lo + (hi - lo) / 2;
            if (key < array[m]) return rank(key, lo, m - 1, array);
            else if (key > array[m]) return rank(key, m + 1, hi, array);
            else
            {
                while (--m > 0 && array[m] == key) ;
                return m + 1;
            }
        }
        static int count(int key, int[] array)
        {
            int lessIndex = rank(key, array);
            while (++lessIndex < array.Length && array[lessIndex] == key) ;
            return lessIndex;
        }
        static void Main(string[] args)
        {
            var array = (new List<int> { 1, 2, 2, 3, 3, 4, 5, 6 }).ToArray();
            Console.WriteLine($"rank:{rank(3, array)}");
            Console.WriteLine($"count:{count(3, array)}");
        }
    }
}
