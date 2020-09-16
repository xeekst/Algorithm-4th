using System.Collections;

namespace LinkedList
{
    public interface ILinkList<TData>
    {
        Node<TData> Head { get; }
        int Count { get; }
        int Size();

        void InsertTail(TData data);

        void InsertHead(TData data);

        TData DeleteHead();

        TData DeleteTail();

    }
}