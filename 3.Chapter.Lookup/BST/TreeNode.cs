using System;

namespace BST
{
    public class TreeNode<TKey, TValue> where TKey : IComparable where TValue : IComparable
    {
        public TKey Key;
        public TValue Value;
        public TreeNode<TKey, TValue> Left;
        public TreeNode<TKey, TValue> Right;
        public int Count ;
        public TreeNode(TKey key, TValue value, int count)
        {
            Key = key;
            Value = value;
            Count = count;
        }
    }
}
