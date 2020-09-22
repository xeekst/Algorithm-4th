using System.Collections;

namespace Ex_1._3._31
{
    public interface ILinkList<TData>
    {
        DoubleNode<TData> Head { get; }
        int Count { get; }
        int Size();

        void InsertTail(TData data);

        void InsertHead(TData data);

        TData DeleteHead();

        TData DeleteTail();

    }
}