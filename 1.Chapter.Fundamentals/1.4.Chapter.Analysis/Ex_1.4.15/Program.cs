using System;
using System.Linq;

namespace Ex_1._4._15
{
    class Program
    {
        /// <summary>
        /// O(N) 2-sum
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int TwoSumFaster(int[] nums)
        {
            int count = 0;
            int i = 0, h = nums.Length - 1;
            while (i < h)
            {
                int t = nums[i] + nums[h];
                if (t == 0)
                {
                    count++;
                    i++;
                    h--;
                }
                else if (t > 0)
                {
                    h--;
                }
                else
                {
                    i++;
                }
            }
            return count;
        }

        /// <summary>
        /// O(N^2) 3-sum
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ThreeSumFaster(int[] nums)
        {
            int count = 0;

            for (int index = 0; index < nums.Length; index++)
            {
                int i = index + 1, h = nums.Length - 1;
                while (i < h)
                {
                    int t = nums[i] + nums[index] + nums[h];
                    if (t == 0)
                    {
                        count++;
                        i++;
                        h--;
                    }
                    else if (t > 0)
                    {
                        h--;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return count;
        }
        static void Main(string[] args)
        {

            var array = Enumerable.Range(-443,2327).ToArray();

            Console.WriteLine(ThreeSumFaster(array));
        }
    }
}
