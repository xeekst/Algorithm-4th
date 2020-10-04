using System;

namespace Ex_2._3._27
{
    public class QuickSortLastToInsertSort : SortAbstract
    {
        private InsertSort _insertSort = new InsertSort();
        public override void Sort(IComparable[] a)
        {
            Sort(a, 0, a.Length - 1);
            _insertSort.Sort(a, 0, a.Length - 1);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            // 太小的直接忽略
            if (hi - lo <= 7)
            {
                return;
            };
            int p = Partition(a, lo, hi);
            Sort(a, lo, p - 1);
            Sort(a, p + 1, hi);
        }
        int count = 0;
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
