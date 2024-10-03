using System.Collections.Generic;

namespace Fuyu.Common.Collections
{
    // NOTE: Why not ConcurrentDictionary<T1, T2>? Because it's horribly slow
    //       in .NET 8.0, let alone .NET Framework 4.7.1. Manual locking is
    //       about 700x faster in most use-cases.
    // -- seionmoya, 2024/09/03

    public class ThreadDictionary<T1, T2>
    {
        private readonly Dictionary<T1, T2> _dictionary;
        private readonly object _lock;

        public ThreadDictionary()
        {
            _dictionary = new Dictionary<T1, T2>();
            _lock = new object();
        }

        public ThreadDictionary(IDictionary<T1, T2> enumerable)
        {
            _dictionary = new Dictionary<T1, T2>(enumerable);
            _lock = new object();
        }

        public Dictionary<T1, T2> ToDictionary()
        {
            lock (_lock)
            {
                return _dictionary;
            }
        }

        public T2 Get(T1 key)
        {
            lock (_lock)
            {
                return _dictionary[key];
            }
        }

        public bool TryGet(T1 key, out T2 value)
        {
            lock (_lock)
            {
                return _dictionary.TryGetValue(key, out value);
            }
        }

        public void Set(T1 key, T2 value)
        {
            lock (_lock)
            {
                _dictionary[key] = value;
            }
        }

        public void Add(T1 key, T2 value)
        {
            lock (_lock)
            {
                _dictionary.Add(key, value);
            }
        }

        public void Remove(T1 key)
        {
            lock (_lock)
            {
                _dictionary.Remove(key);
            }
        }

        public bool ContainsKey(T1 key)
        {
            lock(_lock)
            {
                return _dictionary.ContainsKey(key);
            }
        }
    }
}