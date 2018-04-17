namespace NET.S._2018.Dvorkin.Task1
{
    public sealed class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
    }
}