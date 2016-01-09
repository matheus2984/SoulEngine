namespace Soul.Engine
{
    public class LastObjectData<T>
    {
        public T Current { get; private set; }
        public T Last { get; private set; }

        public void SetCurrent(T current)
        {
            Last = Current;
            Current = current;
        }
    }
}