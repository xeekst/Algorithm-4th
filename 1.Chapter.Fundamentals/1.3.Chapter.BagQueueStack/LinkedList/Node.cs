namespace LinkedList
{
    public class Node<TData>
    {
        public TData Data = default(TData);
        public Node<TData> Next = null;
    }
}