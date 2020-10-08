using System;

namespace SymbolTable
{
    public interface IST<TKey, TValue> where TKey : IComparable
    {
        int Count { get; }
        void Put(TKey key, TValue value);
        Node<TKey, TValue> Get(TKey key);
        Node<TKey, TValue> Delete(TKey key);
        bool Contains(TKey key);
        bool IsEmpty();
    }
}
