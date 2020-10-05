using System;
using System.Linq;
using Sorts;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueueImpl<IComparable> _queue = new PriorityQueueImpl<IComparable>(50000);
            var testArray = Utils.GenRandomArray(5000);
            testArray.ToList().ForEach(e =>
            {
                _queue.Insert(e);
            });
            Console.WriteLine($"Count:{_queue.Count}");
            for(int i =0;i<=_queue.Count;i++){
                Console.Write($"{_queue.DelMax()} ");
            }

        }
    }
}
