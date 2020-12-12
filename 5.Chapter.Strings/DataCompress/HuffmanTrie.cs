using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataCompress
{
    public class HuffmanTrie
    {
        private static int R = 256;

        // 返回bytes
        public static byte[] Compress(string text)
        {
            BitVirtualSteam bvStream = new BitVirtualSteam();
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
            WriteTrie(bvStream, root);
            bvStream.Write(text.Length);
            // var lenBytes = BitConverter.GetBytes(text.Length);
            
            // BitArray array = new BitArray(lenBytes);
            // for (int i = 0; i < array.Length; i++)
            // {
            //     bits.Add(array[i]);
            // }

            for (int i = 0; i < text.Length; i++)
            {
                string code = st[text[i]];
                for (int j = 0; j < code.Length; j++)
                {
                    if (code[j] == '1')
                    {
                        bvStream.Write(true);
                    }
                    else
                    {
                        bvStream.Write(false);
                    }
                }
            }

            return bvStream.GetBytes();
        }

        public static string Expand(byte[] bytes)
        {
            int index = 0;
            BitArray bits = new BitArray(bytes);
            BitVirtualSteam bvStream = new BitVirtualSteam(bytes);
            HuffmanNode root = ReadTrie(bvStream, ref index);
            BitArray lenbs = new BitArray(32);
            for (int i = 0; i < 32; i++)
            {
                lenbs[i] = bits[index++];
            }
            byte[] lenBytes = new byte[4];
            lenbs.CopyTo(lenBytes,0);
            //int N = BitConverter.ToInt32(lenBytes);
            int N = bvStream.ReadInt32();
            char[] chars = new char[N];
            for (int i = 0; i < N; i++)
            {
                HuffmanNode x = root;
                while (!x.isLeaf())
                {
                    //一直往前读取
                    if (bvStream.ReadBoolean())
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
        private static HuffmanNode ReadTrie(BitVirtualSteam bvStream, ref int index)
        {
            if (bvStream.ReadBoolean())
            {
                //byte b = BitsToChar(bits, ref index);
                return new HuffmanNode(bvStream.ReadChar(), 0, null, null);
            }
            return new HuffmanNode('\0', 0, ReadTrie(bvStream, ref index), ReadTrie(bvStream, ref index));
        }
        private static void WriteTrie(BitVirtualSteam bvStream, HuffmanNode x)
        {
            if (x.isLeaf())
            {
                bvStream.Write(true);
                bvStream.Write(x.Ch);
                return;
            }
            bvStream.Write(false);
            WriteTrie(bvStream, x.Left);
            WriteTrie(bvStream, x.Right);
        }
    }
}