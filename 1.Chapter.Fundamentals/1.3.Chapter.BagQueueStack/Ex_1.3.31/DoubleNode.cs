namespace Ex_1._3._31
{
    public class DoubleNode<TData>
    {
        public TData Data = default(TData);
        public DoubleNode<TData> Next = null;
        public DoubleNode<TData> Prev = null;
    }
}