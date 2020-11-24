namespace StringsQuery
{
    public class KMP
    {
        public static int Search(string text, string pat, int R = 256)
        {
            int[][] dfa = GenerateDfa(pat, R);
            int i, j, N = text.Length, M = pat.Length;
            for (i = 0, j = 0; i < N && j < M; i++)
            {
                j = dfa[text[i]][j];
            }
            if (j == M)
            {
                return i - M;
            }
            else
            {
                return -1;
            }
        }

        private static int[][] GenerateDfa(string pat, int R)
        {
            int M = pat.Length;
            int[][] dfa = new int[R][];
            for (int i = 0; i < R; i++)
            {
                dfa[i] = new int[M];
            }
            dfa[pat[0]][0] = 1;
            for (int X = 0, j = 1; j < M; j++)
            {
                for (int c = 0; c < R; c++)
                {
                    dfa[c][j] = dfa[c][X];
                }
                dfa[pat[j]][j] = j + 1; // 匹配成功就向前进一
                X = dfa[pat[j]][X]; // 重启状态更新 => pat[j] 表示当前的 字符,X表示失败 回退到的位置
            }
            return dfa;
        }
    }
}