using System;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string,int> bst = new BinarySearchTree<string, int>();
            bst.Put("D",21);
            
            bst.Put("B",21);
            bst.Put("A",21);
            bst.Put("C",21);
            bst.Put("F",21);
            bst.Put("E",21);
            
            bst.Put("G",21);

            //bst.DeleteMin();
            bst.Delete("B");

            var list = bst.GetKeys("A","Z");
            Console.WriteLine(bst.Select(3).Key);
            Console.WriteLine(bst.Rank("F"));
        }
    }
}
