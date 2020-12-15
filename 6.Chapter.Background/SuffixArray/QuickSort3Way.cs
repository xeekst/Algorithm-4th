using System;

namespace SuffixArray
{
    public class QuickSort3Way : SortAbstract
    {
        public override void Sort(IComparable[] a)
        {
            Sort(a, 0, a.Length - 1);
        }
        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (lo >= hi) return;
            int lt = lo, i = lo + 1, gt = hi;
            IComparable v = a[lo];
            while (i <= gt)
            {
                switch (a[i].CompareTo(v))
                {
                    case -1:
                        Swap(a, i++, lt++);
                        break;
                    case 0:
                        i++;
                        break;
                    case 1:
                        Swap(a, i, gt--);
                        break;
                    default:
                        throw new NullReferenceException();
                }
            }

            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
        }
    }
}
