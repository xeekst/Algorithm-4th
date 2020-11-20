namespace StringsBase
{
    public class Quick3string
    {
        private static int CharAt(string s, int d)
        {
            if (d < s.Length) return s[d];
            return -1;
        }

        public static void Sort(string[] a)
        {
            Sort(a, 0, a.Length - 1, 0);
        }

        private static void Sort(string[] a, int lo, int hi, int d)
        {
            // 长度小于等于1的不排序
            if (lo >= hi) { return; }
            int lt = lo, gt = hi;
            int i = lo + 1;
            int chlo = CharAt(a[lo], d);
            while (i <= gt)
            {
                int chi = CharAt(a[i], d);
                int cmp = chi.CompareTo(chlo);
                switch (cmp)
                {
                    case -1:
                        Swap(a, lt++, i++);
                        break;
                    case 1:
                        Swap(a, gt--, i);
                        break;
                    default:
                        i++;
                        break;
                }
            }
            Sort(a, lo, lt - 1, d);
            if (chlo >= 0) Sort(a, lt, gt, d + 1);
            Sort(a, gt + 1, hi, d);
        }

        private static void Swap(string[] a, int i, int j)
        {
            string tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}