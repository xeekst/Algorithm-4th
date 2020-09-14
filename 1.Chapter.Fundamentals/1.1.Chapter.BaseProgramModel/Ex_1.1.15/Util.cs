using System;

namespace Ex_1._1._15
{
    public class Util
    {
        public static void ShowArray<T>(T[][] array)
        {
            for (int r = 0; r < array.Length; r++)
            {
                for (int c = 0; c < array[r].Length; c++)
                {
                    Console.Write($"  {array[r][c]}");
                }
                Console.WriteLine();
            }
        }
        public static void ShowArray<T>(T[] array)
        {
            for (int r = 0; r < array.Length; r++)
            {
                Console.Write($"  {array[r]}");
            }
            Console.WriteLine();
        }
    }
}