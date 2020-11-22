using System;

namespace StringsSort
{
    public class InsertSort
    {
        public static void Sort(string[] a, int lo, int hi, int d)
        {
            for (int i = lo; i < hi + 1; i++)
            {
                for (int j = i; j > lo && Less(a[j], a[j - 1], d); j--)
                {
                    Swap(a, j, j - 1);
                }
            }
        }

        private static bool Less(string a, string b, int d)
        {
            if (a.Substring(d).CompareTo(b.Substring(d)) < 0)
            {
                return true;
            }
            return false;
        }

        private static void Swap(string[] a, int i, int j)
        {
            string tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}
