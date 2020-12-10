using System;

namespace DataCompress
{
    public class HuffmanNode : IComparable<HuffmanNode>
    {
        public char Ch;
        public int Freq;
        public HuffmanNode Left, Right;

        public HuffmanNode(char ch, int freq, HuffmanNode left, HuffmanNode right)
        {
            Ch = ch;
            Freq = freq;
            Left = left;
            Right = right;
        }

        //是否为空
        public bool isLeaf()
        {
            return Left == null && Right == null;
        }

        public int CompareTo(HuffmanNode huffmanNode)
        {
            return this.Freq.CompareTo(huffmanNode.Freq);
        }
    }
}