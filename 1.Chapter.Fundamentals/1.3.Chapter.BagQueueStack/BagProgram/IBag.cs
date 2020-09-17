using System;
using System.Collections.Generic;

namespace BagProgram
{
    public interface IBag<TData>
    {
        int Count { get; }
        void Add(TData data);
        void ForEach(Action<Node<TData>> node);
    }
}