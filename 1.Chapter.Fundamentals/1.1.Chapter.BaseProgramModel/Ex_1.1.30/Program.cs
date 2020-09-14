using System;
using Ex_1._1._13;

namespace Ex_1._1._30
{
    class Program
    {
        static uint Gcd(uint a, uint b)
        {
            uint min = a;
            uint max = b;
            if (a > b)
            {
                min = b;
                max = a;
            }
            else if (b > a)
            {
                max = b;
                min = a;
            }
            else return a;

            uint m = max % min;
            if (m == 0) return min;
            else return Gcd(min, m);
        }
        static bool[][] Create(int m, int n)
        {
            bool[][] array = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                int rowNum = i + 1;
                bool[] row = new bool[n];
                for (int j = 0; j < n; j++)
                {
                    int colNum = j + 1;
                    row[j] = Gcd((uint)rowNum, (uint)colNum) == 1 ? true : false;
                }
                array[i] = row;
            }
            return array;
        }
        static void Main(string[] args)
        {
            var a = Create(12,13);
            Util.ShowArray(a);
            Console.WriteLine("Hello World!");
        }
    }
}
