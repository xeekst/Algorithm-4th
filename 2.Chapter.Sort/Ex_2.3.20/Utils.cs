using System;

namespace Ex_2_3_20
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

        public static IComparable[] GenRandomRepeatArray(int n,int repeat = 50){
            IComparable[] baseArray = new IComparable[repeat];
            for(int i=0;i<repeat;i++){
                int g = Math.Abs(Guid.NewGuid().GetHashCode()) % int.MaxValue;
                baseArray[i] = g;
            }

            IComparable[] array = new IComparable[n];
            for (int i = 0; i < n; i++)
            {
                int index = Math.Abs(Guid.NewGuid().GetHashCode()) % repeat;
                array[i] = baseArray[index];
            }
            return array;
        }
    }
}
