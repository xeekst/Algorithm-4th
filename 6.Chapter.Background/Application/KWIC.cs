using System;
using System.Collections.Generic;

namespace Application
{
    public class KWIC
    {
        public static string[] GetContexts(string sourceText, string key, int len)
        {
            int N = sourceText.Length;
            SuffixArray suffix = new SuffixArray(sourceText);
            List<string> contexts = new List<string>();

            for (int i = suffix.Rank(key); i < N && suffix.Select(i).StartsWith(key); i++)
            {
                int from = Math.Max(0, suffix.Index(i) - len);
                int count = Math.Min(N - 1, key.Length + 2 * len);
                contexts.Add(sourceText.Substring(from, count));
            }
            return contexts.ToArray();
        }
    }
}