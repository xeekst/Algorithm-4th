using System;

namespace Ex_2_3_17
{
    public class QuickSortSentry : SortAbstract
    {
        public override void Sort(IComparable[] a)
        {
            // 把最大值置于数组末尾
            int maxIndex = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (Less(a[maxIndex], a[i])) maxIndex = i;
            }
            Swap(a, maxIndex, a.Length - 1);

            // 排序
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (lo >= hi) return;
            int p = Partition(a, lo, hi);
            Sort(a, lo, p - 1);
            Sort(a, p + 1, hi);
        }
        private int Partition(IComparable[] a, int lo, int hi)
        {
            if (lo >= hi) return lo;
            IComparable v = a[lo];
            int i = lo, j = hi + 1;
            while (true)
            {
                while (Less(a[++i], v)) ;
                while (Less(v, a[--j])) ;
                if (j <= i) break;
                Swap(a, i, j);
            }
            Swap(a, lo, j);
            return j;
        }
    }
}