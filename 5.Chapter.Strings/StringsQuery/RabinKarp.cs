namespace StringsQuery
{
    public class RabinKarp
    {
        private string _pat;
        private long _patHash;
        private int M;
        private long Q;
        private int R = 256; //ASCII 表大小
        private long RM; // R^(M-1) % Q

        public RabinKarp(string pat)
        {
            _pat = pat;
            M = pat.Length;
            Q = 9973;
            RM = 1;
            for (int i = 1; i < pat.Length; i++)
            {
                RM = (RM * R) % Q;
            }
            _patHash = Hash(pat, M);
        }

        // 蒙卡洛特算法 —— 两次计算10^20的以下的一个素数的模，这样重复的几率降低到 1/10^40 一下
        public bool Check(int i)
        {
            return true;
        }

        public int Search(string text)
        {
            int N = text.Length;
            long textHash = Hash(text, M);
            if (_patHash == textHash && Check(0)) return 0;
            for (int i = M; i < N; i++)
            {
                // 减去前一个的数字，然后加上最后一个数字
                textHash = (textHash + Q - RM * text[i - M] % Q) % Q;
                textHash = (textHash * R + text[i]) % Q;
                if (_patHash == textHash && Check(i - M + 1))
                    return i - M + 1;
            }
            return -1;
        }

        private long Hash(string pat, int M)
        {
            long h = 0;
            for (int j = 0; j < M; j++)
            {
                h = (R * h + pat[j]) % Q;
            }
            return h;
        }
    }
}