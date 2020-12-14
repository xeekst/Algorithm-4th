using System;

namespace Application
{
    //后缀数组
    public class SuffixArray
    {
        private string[] _suffixes;
        private int N;
        public SuffixArray(string s)
        {
            N = s.Length;
            _suffixes = new string[N];
            for (int i = 0; i < N; i++)
            {
                _suffixes[i] = s.Substring(i);
            }
            QuickSort3Way quickSort = new QuickSort3Way();
            quickSort.Sort(_suffixes);
        }
        public int Length => N;
        public string Select(int i)
        {
            return _suffixes[i];
        }
        public int Lcp(string s1, string s2)
        {
            int N = Math.Min(s1.Length, s2.Length);
            for (int i = 0; i < N; i++)
            {
                if (s1[i] != s2[i]) return i;
            }
            return N;
        }

        public int Rank(string key)
        {
            int lo = 0, hi = N - 1;
            while (lo <= hi)
            {
                int m = lo + (hi - lo) / 2;
                string v = _suffixes[m];
                int cmp = key.CompareTo(v);
                if (cmp < 0)
                {
                    hi = m - 1;
                }
                else if (cmp > 0)
                {
                    lo = m + 1;
                }
                else
                {
                    return m;
                }
            }
            return lo;
        }
    }
}