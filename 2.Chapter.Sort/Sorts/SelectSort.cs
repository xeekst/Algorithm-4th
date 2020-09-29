using System;

namespace Sorts
{
    /// <summary>
    /// 选择排序
    /// 1. 遍历 0 -> n-1 的元素，2. 选择余下元素中最小的那个，3. 与当前的元素交换
    /// O(N^2)
    /// </summary>
    public class SelectSort : SortAbstract
    {
        public override void Sort(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (Less(a[j], a[minIndex]))
                    {
                        minIndex = j;
                    }
                }
                Swap(a, i, minIndex);
            }
        }
    }
}
