using System;

namespace Sorts
{
    public class ShellSort : SortAbstract
    {
        public override void Sort(IComparable[] a)
        {
            int h3 = 1;
            while (h3 < a.Length / 3) h3 = h3 * 3 + 1;

            while (h3 > 0)
            {
                for (int i = h3; i < a.Length; i++)
                {
                    for (int j = i; j - h3 >= 0 && Less(a[j], a[j - h3]); j -= h3)
                    {
                        Swap(a, j, j - h3);
                    }
                }
                h3 = h3 / 3;
            }
        }
    }
}
