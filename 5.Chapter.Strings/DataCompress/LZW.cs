namespace DataCompress
{
    public class LZW
    {
        private static int R = 256;
        private static int L = 4096;
        private static int W = 12; // 编码宽度

        public static byte[] Compress(string input)
        {
            BitVirtualSteam bvStream = new BitVirtualSteam();
            ThreeTrieST<int> tst = new ThreeTrieST<int>();
            for (int i = 0; i < R; i++)
            {
                tst.Put(((char)i).ToString(), i);
            }
            int code = R + 1;
            while (input.Length > 0)
            {
                string s = tst.LongestPrefixOf(input);
                bvStream.Write(tst.Get(s), 12);
                int t = s.Length;
                if (t < input.Length && code < L)
                {
                    tst.Put(input.Substring(0, t + 1), code++);
                }
                input = input.Substring(t);
            }
            bvStream.Write(R, W);

            return bvStream.GetBytes();
        }

        public static string Expand(byte[] bytes)
        {
            BitVirtualSteam bvStream = new BitVirtualSteam(bytes);
            string[] st = new string[L];
            int i;
            for (i = 0; i < R; i++)
            {
                st[i] = ((char)i).ToString();
            }
            st[i++] = " ";
            int codeword = bvStream.ReadInt(W);
            string val = st[codeword];
            string output = string.Empty;
            // 边解码边增加新码
            while (true)
            {
                output += val;
                codeword = bvStream.ReadInt(W);
                if (codeword == R) break;
                string s = st[codeword]; // 下一个编码
                if (i == codeword) // 当前的前瞻字符不可用
                {
                    s = val + val[0]; // 由上一个字符串的首字母加该字符串得到的当前字符串
                }
                if (i < L)
                {
                    st[i++] = val + s[0]; // 编码表新增
                }
                val = s; //更新编码
            }
            return output;
        }
    }
}