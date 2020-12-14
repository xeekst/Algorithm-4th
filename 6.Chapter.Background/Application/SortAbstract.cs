using System;

namespace Application
{
    public abstract class SortAbstract
    {
        public abstract void Sort(IComparable[] a);

        protected virtual bool Less(IComparable a, IComparable b)
        {
            if (a.CompareTo(b) < 0)
            {
                return true;
            }
            return false;
        }

        protected virtual void Swap(IComparable[] a, int i, int j)
        {
            IComparable tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }

        public virtual void Show(IComparable[] a)
        {
            for (int index = 0; index < a.Length; index++)
            {
                Console.Write($"{a[index]} ");
            }
            Console.WriteLine();
        }

        public virtual bool IsSorted(IComparable[] a)
        {
            for (int index = 0; index < a.Length - 1; index++)
            {
                if (a[index].CompareTo(a[index + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
