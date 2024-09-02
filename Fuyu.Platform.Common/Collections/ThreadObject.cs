namespace Fuyu.Platform.Common.Collections
{
    public class ThreadObject<T>
    {
        private T _object;
        private readonly object _lock;

        public ThreadObject(T value)
        {
            _object = value;
            _lock = new object();
        }

        public T Get()
        {
            return _object;
        }

        public void Set(T value)
        {
            lock (_lock)
            {
                _object = value;
            }
        }
    }
}