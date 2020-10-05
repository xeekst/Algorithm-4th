using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sorts
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
            TestSort(new MergeSort(), testArray);
            // TestSort(new ShellSort());
            TestSort(new QuickSort(), testArray);
            //TestSort(new QuickSort3Way(), testArray);
            //TestSort(new QuickSortLittleArrayToInsertSort(),testArray);
            TestSort(new HeapSort(), testArray);
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
