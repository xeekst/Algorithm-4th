using System;

namespace RedBlackBST
{
    public class TreeNode<TKey, TValue> where TKey : IComparable where TValue : IComparable
    {
        public TKey Key;
        public TValue Value;
        public NodeColor Color = NodeColor.BLACK;
        public TreeNode<TKey, TValue> Left;
        public TreeNode<TKey, TValue> Right;
        public int N = 1;

        public TreeNode(TKey key, TValue value, NodeColor color)
        {
            Key = key;
            Value = value;
            Color = color;
        }
    }
}
