using System;

namespace Sorts
{
    public class InsertSort : SortAbstract
    {
        public override void Sort(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                //找到 恰好大于 i 的那个元素 j => [0,i)
                for (int j = 0; j < i; j++)
                {
                    if (Less(a[i], a[j]))
                    {
                        IComparable tmp = a[i];
                        MoveNext(a, j, i - 1);
                        a[j] = tmp;
                    }
                }
            }
        }

        /// <summary>
        /// 把 [endIndex,startIndex]的元素都往后移动一位
        /// </summary>
        /// <param name="a"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        private void MoveNext(IComparable[] a, int startIndex, int endIndex)
        {
            int moveIndex = endIndex;
            while (moveIndex >= startIndex && moveIndex < a.Length - 1)
            {
                a[moveIndex + 1] = a[moveIndex];
                moveIndex--;
            }
        }
    }
}
