namespace QueueProgram
{
    public interface IQueue<TData>
    {
        void Enqueue(TData data);

        TData Dequeue();

        int Size();
    }
}