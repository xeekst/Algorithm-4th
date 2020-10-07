using System;
using System.Diagnostics;
using System.Linq;
using Sorts;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueueImpl<IComparable> _queue = new PriorityQueueImpl<IComparable>(1000000);
            PriorityQueueLinked<IComparable> _queueLinked = new PriorityQueueLinked<IComparable>();
            var testArray = Utils.GenRandomArray(500000);
            var test1 = new IComparable[500000];
            var test2 = new IComparable[500000];
            testArray.CopyTo(test1, 0);
            testArray.CopyTo(test2, 0);


            Stopwatch sw = new Stopwatch();

            testArray.ToList().ForEach(e =>
            {
                _queue.Insert(e);
            });
            sw.Start();
            bool isSorted = true;
            IComparable max = int.MaxValue;
            while (_queue.Count > 0)
            {
                var m = _queue.DelMax();
                if (max.CompareTo(m) < 0)
                {
                    isSorted = false;
                }
                max = m;
                //Console.Write(_queue.DelMax() + " ");
            }
            sw.Stop();
            //sortor.Show(testArray);
            Console.WriteLine($"======================================_queue:.Name:isSorted:{isSorted} time: {sw.ElapsedMilliseconds}==================================");

            Stopwatch sw2 = new Stopwatch();

            testArray.ToList().ForEach(e =>
            {
                _queueLinked.Insert(e);
            });
            sw2.Start();
            max = int.MaxValue;
            isSorted = true;
            while (_queueLinked.Count > 0)
            {
                var m = _queueLinked.DelMax();
                if (max.CompareTo(m) < 0)
                {
                    isSorted = false;
                }
                max = m;
                //Console.Write(_queueLinked.DelMax() + " ");
            }
            sw2.Stop();
            //sortor.Show(testArray);
            Console.WriteLine($"======================================_queueLinked:.Name:isSorted:{isSorted} t:{sw2.ElapsedMilliseconds}==================================");



            // Console.WriteLine($"Count:{_queue.Count}");
            // for(int i =0;i<=_queue.Count;i++){
            //     Console.Write($"{_queue.DelMax()} ");
            // }


        }

    }
}
