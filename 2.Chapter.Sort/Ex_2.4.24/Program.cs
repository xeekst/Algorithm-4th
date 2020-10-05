using System;
using System.Linq;
using Ex_2_4_24;
using Sorts;

namespace Ex_2._4._24
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArray = Utils.GenRandomArray(50);
            //testArray = new IComparable[7] { 1, 2, 3, 4, 5, 6, 7 };
            var pql = new PriorityQueueLinked<IComparable>();
            testArray.ToList().ForEach(e =>
            {
                pql.Insert(e);
            });

            while (pql.Count > 0)
            {
                Console.Write(pql.DelMax() + " ");
            }

            Console.WriteLine();
        }
    }
}
