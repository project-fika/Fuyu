using System.Collections.Generic;

namespace Fuyu.Platform.Common.Collections
{
    // NOTE: Why not ConcurrentBag<T>? While it's performance is very fast in
    //       in intensive parallel access under .NET 8.0, it leaves a lot to be
    //       desired in .NET Framework 4.7.1. For random read-write, List with
    //       manual lock was still faster for me.

    public class ThreadList<T>
    {
        private readonly List<T> _list;
        private readonly object _lock;

        public ThreadList()
        {
            _list = new List<T>();
            _lock = new object();
        }

        public List<T> ToList()
        {
            return _list;
        }

        public T Get(int index)
        {
            return _list[index];
        }

        public void Set(int index, T value)
        {
            lock (_lock)
            {
                _list[index] = value;
            }
        }

        public void Add(T value)
        {
            lock (_lock)
            {
                _list.Add(value);
            }
        }

        public void Remove(T value)
        {
            lock (_lock)
            {
                _list.Remove(value);
            }
        }

        public void RemoveAt(int index)
        {
            lock (_lock)
            {
                _list.RemoveAt(index);
            }
        }
    }
}