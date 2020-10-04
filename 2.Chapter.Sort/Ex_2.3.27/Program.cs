using System;
using System.Diagnostics;
using Ex_2_3_27;

namespace Ex_2._3._27
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 500000;
            var testArray = Utils.GenRandomArray(n);
            var testRepeatArray = Utils.GenRandomRepeatArray(n, 50);

            // TestSort(new BubbingSort());
            // TestSort(new SelectSort());
            // TestSort(new InsertSort());
            TestSort(new QuickSortLastToInsertSort(),testArray);
        }

        private static void TestSort(SortAbstract sortor, IComparable[] a)
        {

            var tmp = new IComparable[a.Length];
            a.CopyTo(tmp, 0);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            sortor.Sort(tmp);
            sw.Stop();
            //sortor.Show(testArray);
            Console.WriteLine($"======================================sort:IsSorted:{sortor.IsSorted(tmp)} {sortor.GetType().Name}:{sw.ElapsedMilliseconds}==================================");

        }
    }
}
