using System;
using System.Linq;

namespace Sorts
{
    public class HeapSort : SortAbstract
    {
        private IComparable[] _heap;
        public override void Sort(IComparable[] a)
        {
            _heap = new IComparable[a.Length + 1];
            a.CopyTo(_heap, 1);
            Sort(_heap.Length - 1);
            for (int i = 1; i < _heap.Length; i++)
            {
                a[i - 1] = _heap[i];
            }
        }

        private void Sort(int maxIndex)
        {
            // 堆排序 第一步：忽略最后一层，从次一层开始构建堆（从最小三个节点的堆开始），至最后整个堆有序
            for (int k = maxIndex / 2; k >= 1; k--)
            {
                Sink(k, maxIndex);
            }
            // 第二步：逐步把最大堆元素置于末尾，然后逐渐缩小堆的规模 —— 每次末尾都放置当前堆最大值
            // 实际就是N个元素 第一次放置 第一大到末尾，第二次放置 第二大到末尾...... 第n次放置第n大到末尾 
            while (maxIndex > 1)
            {
                Swap(_heap, 1, maxIndex);
                Sink(1, --maxIndex);
            }
        }

        private void Sink(int index, int maxIndex)
        {
            while (2 * index <= maxIndex)
            {
                int maxChild = 2 * index;
                //找到两个子节点 更大的那个节点
                if (maxChild + 1 <= maxIndex && _heap[maxChild].CompareTo(_heap[maxChild + 1]) < 0) maxChild++;
                //如果 k 小于最大的子节点，那就下沉交换
                if (_heap[index].CompareTo(_heap[maxChild]) < 0)
                {
                    Swap(_heap, index, maxChild);
                    index = maxChild;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
