using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace DataCompress
{
    // todo 改为更为通用的方式
    public class HuffmanTrie
    {
        private static int R = 256;

        // 返回bytes
        public static BitArray Compress(string text)
        {
            char[] chars = text.ToCharArray();
            // 统计频次
            int[] freqs = new int[R];
            for (int i = 0; i < chars.Length; i++)
            {
                freqs[chars[i]]++;
            }
            HuffmanNode root = BuildTrie(freqs);
            // 构造编译表 每个字母 对应一个 code 字符串
            string[] st = new string[R];
            BuildCode(st, root, "");

            List<bool> bits = new List<bool>();
            WriteTrie(bits, root);
            BitArray array = new BitArray(BitConverter.GetBytes(bits.Count));
            for (int i = 0; i < array.Length; i++)
            {
                bits.Add(array[i]);
            }

            for (int i = 0; i < text.Length; i++)
            {
                string code = st[text[i]];
                for (int j = 0; j < code.Length; j++)
                {
                    if (code[j] == '1')
                    {
                        bits.Add(true);
                    }
                    else
                    {
                        bits.Add(false);
                    }
                }
            }

            BitArray tbits = new BitArray(bits.ToArray());

            //与《算法-第四版》对应长度
            byte[] bytes = new byte[Convert.ToInt32(Math.Ceiling(tbits.Length / 8.0))];
            tbits.CopyTo(bytes, 0);
            
            return tbits;
        }

        public static string Expand(BinaryReader reader)
        {
            HuffmanNode root = ReadTrie(reader);
            int N = reader.ReadInt32();
            char[] chars = new char[N];
            for (int i = 0; i < N; i++)
            {
                HuffmanNode x = root;
                while (!x.isLeaf())
                {
                    //一直往前读取
                    if (reader.ReadBoolean())
                    {
                        x = x.Right;
                    }
                    else
                    {
                        x = x.Left;
                    }
                }
                chars[i] = x.Ch;
            }
            return string.Join("", chars);
        }
        private static string[] BuildCode(HuffmanNode root)
        {
            string[] st = new string[R];
            BuildCode(st, root, "");
            return st;
        }

        private static void BuildCode(string[] st, HuffmanNode x, string s)
        {
            if (x.isLeaf())
            {
                st[x.Ch] = s;
                return;
            }
            BuildCode(st, x.Left, s + '0');
            BuildCode(st, x.Right, s + '1');
        }

        private static HuffmanNode BuildTrie(int[] freqs)
        {
            // 对字母表进行频次如优先队列
            MinPQ<HuffmanNode> pq = new MinPQ<HuffmanNode>(1000);
            for (char ch = (char)0; ch < R; ch++)
            {
                if (freqs[ch] > 0)
                {
                    pq.Insert(new HuffmanNode(ch, freqs[ch], null, null));
                }
            }

            //合成频率相关最小的树
            while (pq.Count > 1)
            {
                HuffmanNode x = pq.DelMin();
                HuffmanNode y = pq.DelMin();
                HuffmanNode parent = new HuffmanNode('\0', x.Freq + y.Freq, x, y);
                pq.Insert(parent);
            }
            return pq.DelMin();
        }

        // 先序读取构造一颗huffman树
        private static HuffmanNode ReadTrie(BinaryReader reader)
        {
            if (reader.ReadBoolean())
            {
                return new HuffmanNode(reader.ReadChar(), 0, null, null);
            }
            return new HuffmanNode('\0', 0, ReadTrie(reader), ReadTrie(reader));
        }
        private static void WriteTrie(List<bool> bits, HuffmanNode x)
        {
            if (x.isLeaf())
            {
                bits.Add(true);
                bits.AddRange(CharToBits(x.Ch));
                return;
            }
            bits.Add(false);
            WriteTrie(bits, x.Left);
            WriteTrie(bits, x.Right);
        }

        private static bool[] CharToBits(char ch)
        {
            byte b = Convert.ToByte(ch);
            var bitArray = new BitArray(new byte[] { b });
            bool[] bits = new bool[8];

            for (int i = 7; i >= 0; i--)
            {
                bits[7 - i] = bitArray[i];
            }
            return bits;
        }

    }
}