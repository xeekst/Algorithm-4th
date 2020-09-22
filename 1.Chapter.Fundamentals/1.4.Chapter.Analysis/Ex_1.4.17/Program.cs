using System;
using System.Collections.Generic;

namespace Ex_1._4._17
{
    class Program
    {
        /// <summary>
        /// O(N) 最远的两个数
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double[] FarestTwo(double[] array)
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            for (int index = 0; index < array.Length; index++)
            {
                if (min > array[index]) min = array[index];
                if (max < array[index]) max = array[index];
            }

            return new double[2] { min, max };
        }

        static void Main(string[] args)
        {
            var list = new List<double>();
            for (int i = 0; i < 10000; i++)
            {
                double r1 = (new Random()).NextDouble() + (new Random()).Next(-2434233, 2434233);
                list.Add(r1);
            }
            var rs2 = FarestTwo(list.ToArray());
            Console.WriteLine($"FarestTwo rs:{rs2[0]},{rs2[1]}");
        }
    }
}
