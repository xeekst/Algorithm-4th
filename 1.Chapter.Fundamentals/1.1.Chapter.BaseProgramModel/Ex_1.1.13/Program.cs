using System;
using System.Linq;

namespace Ex_1._1._13
{
    class Program
    {
                /// <summary>
        /// 1.1.13 数组转置
        /// </summary>
        /// <param name="array"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        static T[][] Transpose<T>(T[][] array)
        {
            if (array.Length < 1) return null;
            int len = array[0].Length;
            int high = array.Length;
            var newArray = new T[len][];
            for (int c = 0; c < len; c++)
            {
                newArray[c] = new T[high];
                for (int r = 0; r < high; r++)
                {
                    newArray[c][r] = array[r][c];
                }
            }
            Util.ShowArray(newArray);
            return newArray;
        }

        static void Main(string[] args)
        {
            var array = new int[2][];
            array[0] = Enumerable.Range(1, 2).ToArray();
            array[1] = Enumerable.Range(32, 2).ToArray();
            array = Transpose<int>(array);
            Console.WriteLine("====================================");
            array = Transpose<int>(array);
        }
    }
}
