using System;
using System.Collections.Generic;

namespace Ex_2_3_20
{
    public class QuickSort : SortAbstract
    {
        Stack<int[]> stack = new Stack<int[]>();
        public override void Sort(IComparable[] a)
        {
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            stack.Push(new int[2] { lo, hi });
            while (stack.Count > 0)
            {
                int[] indexs = stack.Pop();
                int i = indexs[0];
                int j = indexs[1];
                if (i >= j) continue;
                int p = Partition(a, i, j);
                stack.Push(new int[2] { p + 1, j });
                stack.Push(new int[2] { i, p - 1 });
            }
        }
        public int Partition(IComparable[] a, int lo, int hi)
        {
            IComparable k = a[lo];
            int i = lo;
            int j = hi + 1;
            while (true)
            {
                while (Less(a[++i], k))
                {
                    if (i == hi) break;
                }

                while (Less(k, a[--j]))
                {
                    if (j == lo) break;
                }
                if (j <= i) break;
                Swap(a, i, j);
            }
            Swap(a, lo, j);
            return j;
        }
    }
}
