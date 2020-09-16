using System;
using System.Linq;

namespace QueueProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            IQueue<int> queue = new LinkedQueue<int>();
            foreach (var i in Enumerable.Range(0, 10000))
            {
                queue.Enqueue(i);
                if (i % 100 == 0)
                {
                    var data = queue.Dequeue();
                    Console.WriteLine($"{i} % 100 = {i % 100}\tqueue.Dequeue:{data}");
                }
            }
        }
    }
}
