using System;

namespace Fuyu.Common.Collections
{
	public readonly struct Union<T1, T2> : IUnion
		where T1 : IEquatable<T1>
		where T2 : IEquatable<T2>
	{
		// NOTE: While we could just use object I have intentionally used
		// separate fields here in order to avoid boxing value types
		// -- nexus4880, 2024-10-22
		private readonly T1 _value1;
		private readonly T2 _value2;
		private readonly bool _isValue1;

		public T1 Value1
		{
			get
			{
				if (!_isValue1)
				{
					throw new InvalidOperationException();
				}

				return _value1;
			}
		}

		public T2 Value2
		{
			get
			{
				if (_isValue1)
				{
					throw new InvalidOperationException();
				}

				return _value2;
			}
		}

		public bool IsValue1
		{
			get
			{
				return _isValue1;
			}
		}

		object IUnion.Value
		{
			get
			{
				// NOTE: In C# 7.3 at least one of these needs to be casted to object
				// in order to represent a common type
				// -- nexus4880, 2024-10-14
				return IsValue1 ? (object)Value1 : (object)Value2;
			}
		}

		public Union(T1 value)
		{
			_value1 = value;
			_value2 = default;
			_isValue1 = true;
		}

		public Union(T2 value)
		{
			_value1 = default;
			_value2 = value;
			_isValue1 = false;
		}

		public static implicit operator Union<T1, T2>(T1 value)
		{
			return new Union<T1, T2>(value);
		}

		public static implicit operator Union<T1, T2>(T2 value)
		{
			return new Union<T1, T2>(value);
		}

		public static implicit operator T1(Union<T1, T2> union)
		{
			return union.Value1;
		}

		public static implicit operator T2(Union<T1, T2> union)
		{
			return union.Value2;
		}

		public void Match(Action<bool, T1, T2> callback)
		{
			callback(_isValue1, Value1, Value2);
		}

		public void Match(Action<T1> callback)
		{
			if (_isValue1)
			{
				callback(Value1);
			}
		}

		public void Match(Action<T2> callback)
		{
			if (!_isValue1)
			{
				callback(Value2);
			}
		}

		public TResult Match<TResult>(Func<bool, T1, T2, TResult> callback)
		{
			return callback(_isValue1, Value1, Value2);
		}

		public static bool operator ==(Union<T1, T2> lhs, Union<T1, T2> rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Union<T1, T2> lhs, Union<T1, T2> rhs)
		{
			return !lhs.Equals(rhs);
		}

		public override bool Equals(object obj)
		{
			if (obj is Union<T1, T2> union)
			{
				if (IsValue1 && union.IsValue1)
				{
					return Value1.Equals(union.Value1);
				}

				if (!IsValue1 && !union.IsValue1)
				{
					return Value2.Equals(union.Value2);
				}
			}
			else if (obj is T1 t1)
			{
				if (IsValue1)
				{
					return Value1.Equals(t1);
				}
			}
			else if (obj is T2 t2)
			{
				if (!IsValue1)
				{
					return Value2.Equals(t2);
				}
			}

			return false;
		}

		public override int GetHashCode()
		{
			return IsValue1 ? Value1.GetHashCode() : Value2.GetHashCode();
		}

		public override string ToString()
		{
			return IsValue1 ? Value1.ToString() : Value2.ToString();
		}
	}
}