using System;
using System.Diagnostics;
using Ex_2_3_17;

namespace Ex_2._3._17
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 50;
            var testArray = Utils.GenRandomArray(n);

            TestSort(new QuickSortSentry(), testArray);
        }

        private static void TestSort(SortAbstract sortor, IComparable[] a)
        {

            var tmp = new IComparable[a.Length];
            a.CopyTo(tmp, 0);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            sortor.Sort(tmp);
            sw.Stop();
            sortor.Show(tmp);
            Console.WriteLine($"======================================sort:IsSorted:{sortor.IsSorted(tmp)} {sortor.GetType().Name}:{sw.ElapsedMilliseconds}==================================");

        }
    }
}
