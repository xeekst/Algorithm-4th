using System;

namespace SymbolTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayST<string,int> st = new ArrayST<string, int>(100);
            BinarySearchST<string,int> st = new BinarySearchST<string, int>(100);
            st.Put("A",1);
            Console.WriteLine(st.Get("A"));
            st.Put("B",2);
            st.Put("A",3);
            st.Put("C",1);
            st.Delete("A");
            st.Delete("gag");
        }
    }
}
