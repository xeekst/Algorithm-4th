namespace StringsQuery
{
    public class BoyerMooreQuery
    {
        private int[] _right;
        private string pat;
        private int R = 256;

        public BoyerMooreQuery(string pat)
        {
            this.pat = pat;
            int M = pat.Length;
            _right = new int[R];
            for (int c = 0; c < R; c++)
            {
                _right[c] = -1;
            }

            // 生成一个跳表
            for (int j = 0; j < M; j++)
            {
                // right表示这个char在最右边的位置 
                _right[pat[j]] = j; 
            }
        }

        public int Search(string text)
        {
            int N = text.Length;
            int M = pat.Length;
            int skip = 0;
            for (int i = 0; i <= N - M; i += skip)
            {
                skip = 0;
                for (int j = M - 1; j >= 0; j--)
                {
                    //i + j i是起始位置，j是偏移量
                    if (pat[j] != text[i + j])
                    {
                        skip = j - _right[text[i + j]];
                        if (skip < 0) skip = 1;
                        break;
                    }
                }
                if (skip == 0) return i; //找到匹配
            }
            return -1; //未找到匹配
        }
    }
}