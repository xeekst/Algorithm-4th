namespace LinkedList
{
    public interface ILinkList<TData>
    {
        int Count { get; }
        int Size();

        void InsertTail(TData data);

        void InsertHead(TData data);

        TData DeleteHead();
        
        TData DeleteTail();
    }
}