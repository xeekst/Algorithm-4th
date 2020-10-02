using System;
using System.Diagnostics;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestSort(new BubbingSort());
            // TestSort(new SelectSort());
            // TestSort(new InsertSort());
            TestSort(new MergeSort());
            TestSort(new ShellSort());
            TestSort(new QuickSort());
        }

        private static void TestSort(SortAbstract sortor){
            Stopwatch sw = new Stopwatch();
            int n = 50000;
            var testArray = Utils.GenRandomArray(n);
            sw.Start();
            sortor.Sort(testArray);
            sw.Stop();
            //sortor.Show(testArray);
            Console.WriteLine($"======================================{sortor.GetType().Name}:{sw.ElapsedMilliseconds}==================================");

        }
    }
}
