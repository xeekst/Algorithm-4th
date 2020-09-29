using System;
using System.Diagnostics;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int n = 3000;
            BubbingSort bubbingSort = new BubbingSort();
            var testArray1 = Utils.GenRandomArray(n);
            sw.Start();
            bubbingSort.Sort(testArray1);
            sw.Stop();
            bubbingSort.Show(testArray1);
            Console.WriteLine($"===========BubbingSort:{sw.ElapsedMilliseconds}==========");

            SelectSort selectSort = new SelectSort();
            var testArray2 = Utils.GenRandomArray(n);
            sw.Reset();
            sw.Restart();
            selectSort.Sort(testArray2);
            sw.Stop();
            selectSort.Show(testArray2);
            Console.WriteLine($"===========Select Sort:{sw.ElapsedMilliseconds}==========");
        }
    }
}
