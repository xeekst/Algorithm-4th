using System;
using System.Diagnostics;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSort(new BubbingSort());
            TestSort(new SelectSort());
            TestSort(new InsertSort());
        }

        private static void TestSort(SortAbstract sortor){
            Stopwatch sw = new Stopwatch();
            int n = 5000;
            var testArray = Utils.GenRandomArray(n);
            sw.Start();
            sortor.Sort(testArray);
            sw.Stop();
            //sortor.Show(testArray);
            Console.WriteLine($"======================================{sortor.GetType().Name}:{sw.ElapsedMilliseconds}==================================");

        }
    }
}
