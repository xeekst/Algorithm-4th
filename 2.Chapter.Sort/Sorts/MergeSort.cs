using System;

namespace Sorts
{
    public class MergeSort : SortAbstract
    {
        private IComparable[] aux = null;
        public override void Sort(IComparable[] a)
        {
            aux = new IComparable[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(IComparable[] a, int l, int h)
        {
            if (l >= h) return;
            int m = l + (h - l) / 2;
            Sort(a, l, m);
            Sort(a, m + 1, h);
            Merge(a, l, m, h);
        }
        private void Merge(IComparable[] a, int l, int m, int h)
        {
            if (l >= h) return;

            int low = l, index = l;
            for (int i = l, j = m + 1; i <= m || j <= h; index++)
            {
                if (i > m) aux[index] = a[j++];
                else if (j > h) aux[index] = a[i++];
                else if (Less(a[i], a[j])) aux[index] = a[i++];
                else
                {
                    aux[index] = a[j++];
                }
            }
            for (int i = low; i <= h; i++)
            {
                a[i] = aux[i];
            }
        }
    }
}