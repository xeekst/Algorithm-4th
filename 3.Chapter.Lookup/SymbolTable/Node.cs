using System;

namespace SymbolTable
{
    public class Node<TK, TV> where TK : IComparable
    {
        public Node(TK k, TV v)
        {
            Key = k;
            Value = v;
        }
        public TK Key { get; set; }
        public TV Value { get; set; }
    }
}
