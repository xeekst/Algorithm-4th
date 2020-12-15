namespace SuffixArray
{
    public class LRS
    {
        public static string GetLongestSubString(string text)
        {
            int N = text.Length;
            SuffixArray suffix = new SuffixArray(text);
            string lrs = "";
            for (int i = 1; i < N; i++)
            {
                int len = suffix.Lcp(i);
                if (len > lrs.Length)
                {
                    lrs = suffix.Select(i).Substring(0, len);
                }
            }
            return lrs;
        }
    }
}