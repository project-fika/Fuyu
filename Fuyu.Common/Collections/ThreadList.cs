using System;
using System.Collections.Generic;

namespace Fuyu.Common.Collections
{
    // NOTE: Why not ConcurrentBag<T>? While it's performance is very fast in
    //       in intensive parallel access under .NET 8.0, it leaves a lot to be
    //       desired in .NET Framework 4.7.1. For random read-write, List with
    //       manual lock was still faster for me.
    // -- seionmoya, 2024/09/03

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
            lock (_lock)
            {
                return _list;
            }
        }

        public bool TryGet(int index, out T value)
        {
            value = default;
			if (index < 0 || index >= _list.Count)
			{
                return false;
			}

            value = _list[index];
            return true;
		}

		public bool TrySet(int index, T value)
		{
			lock (_lock)
			{
				if (index < 0 || index >= _list.Count)
				{
					return false;
				}

				_list[index] = value;
				return true;
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

		public bool TryRemoveAt(int index)
		{
			lock (_lock)
			{
				if (index < 0 || index >= _list.Count)
				{
					return false;
				}

				_list.RemoveAt(index);
				return true;
			}
		}
	}
}