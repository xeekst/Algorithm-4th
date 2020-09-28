using System;

namespace Sorts
{
    public class Utils
    {
        public static IComparable[] GenRandomArray(int n)
        {
            IComparable[] array = new IComparable[n];
            int n10 = n * 10;
            for (int i = 0; i < n; i++)
            {
                int g = Math.Abs(Guid.NewGuid().GetHashCode()) % n10;
                array[i] = g;
            }
            return array;
        }
    }
}
