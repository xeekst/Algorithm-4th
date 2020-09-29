using System;

namespace Sorts
{
    /// <summary>
    /// 冒泡排序
    /// 每次选择最小的一个一路交换即可
    /// </summary>
    public class BubbingSort : SortAbstract
    {
        public override void Sort(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (Less(a[j], a[i]))
                    {
                        Swap(a, i, j);
                    }
                }
            }
        }
    }
}
