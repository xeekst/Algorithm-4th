using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ILinkList<int> list = new LinkList<int>();
            list.InsertTail(0);
            list.InsertTail(1);
            list.InsertTail(2);
            list.InsertTail(3);
            list.InsertTail(4);
            Node<int> root = list.Head;
            Console.WriteLine("===========遍历============");
            do
            {
                Console.WriteLine(root.Data);
                root = root.Next;
            } while (root != null);
            Console.WriteLine("delete head:{0}", list.DeleteHead());
            Console.WriteLine("delete tail:{0}", list.DeleteTail());
            Console.WriteLine("===========遍历============");
            
            root = list.Head;
            do
            {
                Console.WriteLine(root.Data);
                root = root.Next;
            } while (root != null);
        }
    }
}
