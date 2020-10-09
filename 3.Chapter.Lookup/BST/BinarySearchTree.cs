using System;
using System.Collections.Generic;

namespace BST
{
    public class BinarySearchTree<TKey, TValue> where TKey : IComparable where TValue : IComparable
    {
        private TreeNode<TKey, TValue> _root;

        public TreeNode<TKey, TValue> GetMin(TreeNode<TKey, TValue> node)
        {
            if (node?.Left == null) return node;
            return GetMin(node.Left);
        }

        public TreeNode<TKey, TValue> Get(TKey key)
        {
            var tmpNode = _root;
            return Get(tmpNode, key);
        }
        private TreeNode<TKey, TValue> Get(TreeNode<TKey, TValue> node, TKey key)
        {
            if (node == null) return null;
            switch (key.CompareTo(node.Key))
            {
                case 1:
                    return Get(node.Right, key);
                case 0:
                    return node;
                case -1:
                    return Get(node.Left, key);
                default:
                    return null;
            }
        }
        public void Put(TKey key, TValue value)
        {
            _root = Put(_root, key, value);
        }

        private TreeNode<TKey, TValue> Put(TreeNode<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null) return new TreeNode<TKey, TValue>(key, value, 1);
            switch (key.CompareTo(node.Key))
            {
                case 1:
                    node.Right = Put(node.Right, key, value);
                    break;
                case 0:
                    node.Value = value;
                    break;
                case -1:
                    node.Left = Put(node.Left, key, value);
                    break;
            }
            node.Count = Count(node.Left) + Count(node.Right) + 1;
            return node;
        }

        public void Delete(TKey key)
        {
            _root = Delete(_root, key);
        }

        public IList<TKey> GetKeys(TKey min, TKey max)
        {
            IList<TKey> list = new List<TKey>();
            GetKeys(_root, min, max, list);
            return list;
        }
        private void GetKeys(TreeNode<TKey, TValue> node, TKey min, TKey max, IList<TKey> keyList)
        {
            if (node == null) return;
            int cmpMin = node.Key.CompareTo(min);
            int cmpMax = node.Key.CompareTo(max);
            if (cmpMin > 0) GetKeys(node.Left, min, max, keyList);
            if (cmpMin >= 0 && cmpMax <= 0) keyList.Add(node.Key);
            if (cmpMax < 0) GetKeys(node.Right, min, max, keyList);
        }

        private TreeNode<TKey, TValue> Delete(TreeNode<TKey, TValue> node, TKey key)
        {
            if (node == null) return null;
            switch (key.CompareTo(node.Key))
            {
                case -1:
                    node.Left = Delete(node.Left, key);
                    break;
                case 0:
                    if (node.Left == null) return node.Right;
                    else if (node.Right == null) return node.Left;
                    else
                    {
                        TreeNode<TKey, TValue> tmpNode = node;
                        node = GetMin(tmpNode.Right);
                        node.Right = DeleteMin(tmpNode.Right);
                        node.Left = tmpNode.Left;
                    }
                    break;
                case 1:
                    node.Right = Delete(node.Right, key);
                    break;
            }
            node.Count = Count(node.Left) + Count(node.Right) + 1;
            return node;
        }

        public void DeleteMin()
        {
            _root = DeleteMin(_root);
        }
        // 删除最小值，找到左边最小的node，用它右边的node替换即可
        private TreeNode<TKey, TValue> DeleteMin(TreeNode<TKey, TValue> node)
        {
            // node.Right 有两种可能，1， 为null，2. 不为空，即 parent.Left = child.Right
            if (node.Left == null) return node.Right;
            node.Left = DeleteMin(node.Left);
            node.Count = Count(node.Left) + Count(node.Right) + 1;
            return node;
        }

        // 返回 key前面的元素数量
        public int Rank(TKey key)
        {
            return Rank(_root, key);
        }

        private int Rank(TreeNode<TKey, TValue> node, TKey key)
        {
            if (node == null) return 0;
            switch (key.CompareTo(node.Key))
            {
                case 1:
                    return Count(node.Left) + 1 + Rank(node.Right, key);
                case 0:
                    return Count(node.Left);
                case -1:
                    return Rank(node.Left, key);
            }
            return 0;
        }

        // 返回前面为k个元素的元素 即 第 k+1 个元素
        public TreeNode<TKey, TValue> Select(int k)
        {
            return Select(_root, k);
        }

        private TreeNode<TKey, TValue> Select(TreeNode<TKey, TValue> node, int k)
        {
            if (node == null) return null;
            //左边的数量即它的排名 最初为排名0的node
            int t = Count(node.Left);
            switch (k.CompareTo(t))
            {
                case 1:
                    //包含当前节点 所以+1
                    return Select(node.Right, k - (t + 1));
                case -1:
                    return Select(node.Left, k);
                case 0:
                    return node;
            }
            return null;
        }

        private int Count(TreeNode<TKey, TValue> node)
        {
            if (node == null) return 0;
            else return node.Count;
        }
    }
}
