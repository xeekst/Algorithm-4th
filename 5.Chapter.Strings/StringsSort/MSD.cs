namespace StringsSort
{
    public class MSD
    {

        private static int M = 15;
        private static int CharAt(string s, int d)
        {
            if (d < s.Length)
            {
                return s[d];
            }
            else
            {
                return -1;
            }
        }

        public static void Sort(string[] a,int R)
        {
            int N = a.Length;
            string[] aux = new string[N];
            Sort(a, 0, a.Length - 1, 0, R, aux);
        }

        private static void Sort(string[] a, int lo, int hi, int d, int R, string[] aux)
        {
            if (hi <= lo + M)
            {
                InsertSort.Sort(a, lo, hi, d); return;
            }

            int[] count = new int[R + 2];
            // 频率计数
            for (int i = lo; i <= hi; i++)
            {
                count[CharAt(a[i], d)]++;
            }

            // 计算每个字符的种类的起始索引
            for (int r = 0; r < R + 1; r++)
            {
                count[r + 1] += count[r];
            }

            for (int i = 0; i <= hi; i++)
            {
                aux[count[CharAt(a[i], d) + 1]++] = a[i];
            }

            for (int i = lo; i <= hi; i++)
            {
                a[i] = aux[i - lo];
            }

            for (int r = 0; r < R; r++)
            {
                Sort(a, lo + count[r], lo + count[r + 1] - 1, d + 1, R, aux);
            }
        }
    }
}