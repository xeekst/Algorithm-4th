using System;
using System.Collections.Generic;
using System.Linq;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string, int> bst = new BinarySearchTree<string, int>();
            var nodes = new List<string>() { "A", "X", "C", "S", "E", "R", "H" };
            var balanceBst = BuildPerfectBalanceBST();
            PrintLevel(balanceBst);

            // bst.Put("E", 21);

            // bst.Put("A", 21);
            // bst.Put("S", 21);
            // bst.Put("Y", 21);
            // bst.Put("Q", 21);
            // bst.Put("U", 21);

            // bst.Put("E", 21);
            // bst.Put("S", 21);
            // bst.Put("T", 21);
            // bst.Put("I", 21);
            // bst.Put("O", 21);
            // bst.Put("N", 21);

            // //3.2.2
            // nodes.ForEach(n => bst.Put(n, 1));
            // //bst.DeleteMin();

            // bst.Delete("T");
            // bst.Delete("Y");

            //bst.Visualize()


            var list = bst.GetKeys("A", "Z");
            Console.WriteLine(bst.Select(3).Key);
            Console.WriteLine(bst.Rank("F"));
        }

        //3.2.25 完美平衡
        static BinarySearchTree<string,int> BuildPerfectBalanceBST()
        {
            //3.2.25 完美平衡
            BinarySearchTree<string, int> bst = new BinarySearchTree<string, int>();
            var nodeKeys = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "I", "J", "U", "Z", "X", "C", "S", "E", "R", "H" };
            nodeKeys = nodeKeys.Distinct().ToList();
            nodeKeys.Sort((a, b) => a.CompareTo(b));
            BuildPerfectBalanceBST(nodeKeys, 0, nodeKeys.Count - 1, bst);
            return bst;
        }
        private static void BuildPerfectBalanceBST(List<string> nodeKeys, int lo, int hi, BinarySearchTree<string, int> bst)
        {
            if (lo > hi) return;
            int m = lo + (hi - lo) / 2;
            bst.Put(nodeKeys[m], 1);
            BuildPerfectBalanceBST(nodeKeys, lo, m - 1, bst);
            BuildPerfectBalanceBST(nodeKeys, m + 1, hi, bst);
        }

        //3.2.27 按层次遍历

        public static void PrintLevel(BinarySearchTree<string, int> bst)
        {
            Queue<TreeNode<string, int>> queue = new Queue<TreeNode<string, int>>();
            var tmpQueue = new Queue<TreeNode<string, int>>();
            queue.Enqueue(bst.Root);
            while (queue.Count > 0)
            {
                int nowCount = queue.Count;
                for (int i = 0; i < nowCount; i++)
                {
                    var node = queue.Dequeue();
                    Console.Write(node.Key + " ");
                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
                Console.WriteLine();
            }
        }
    }
}
