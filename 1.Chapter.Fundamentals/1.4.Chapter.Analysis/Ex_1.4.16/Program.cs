using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_1._4._16
{
    class Program
    {
        /// <summary>
        /// O(NLogN) 最近的两个数
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double[] ClosestTwo(double[] array)
        {
            var list = array.ToList();
            list.Sort((a, b) => a.CompareTo(b));
            double[] rs = new double[2] { -1, -1 };
            double min = double.MaxValue;
            for (int index = 0; index < list.Count - 1; index++)
            {
                double r = Math.Abs(list[index + 1] - list[index]);
                if (min > r)
                {
                    min = r;
                    rs[0] = list[index];
                    rs[1] = list[index + 1];
                }
            }
            return rs;
        }

        static void Main(string[] args)
        {
            var list = new List<double>();
            for (int i = 0; i < 10000; i++)
            {
                double r1 = (new Random()).NextDouble() + (new Random()).Next(-2434233, 2434233);
                list.Add(r1);
            }
            var rs1 = ClosestTwo(list.ToArray());
            Console.WriteLine($"ClosestTwo rs:{rs1[0]},{rs1[1]}");
        }
    }
}
