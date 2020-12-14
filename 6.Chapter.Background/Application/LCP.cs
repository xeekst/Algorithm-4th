using System;

namespace Application
{
    public class LCP
    {
        public static int GetLongestPrefixString(string s1, string s2)
        {
            int N = Math.Min(s1.Length, s2.Length);
            for (int i = 0; i < N; i++)
            {
                if (s1[i] != s2[i]) return i;
            }
            return N;
        }
    }
}