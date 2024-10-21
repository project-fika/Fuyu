using System;
using Fuyu.Common.Serialization;
using Newtonsoft.Json;

namespace Fuyu.Common.Hashing
{
	[Serializable]
	[JsonConverter(typeof(MongoIdConverter))]
	public readonly struct MongoId : IComparable<MongoId>, IEquatable<MongoId>
	{
        private static readonly Random _random = new Random();
		private static readonly ulong _processId = Hash;
		private static uint _newIdCounter;
		private readonly uint _timeStamp;
		private readonly ulong _counter;

		public static uint UnixTimestamp
		{
			get
			{
				var startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
				var currTime = DateTime.Now.ToUniversalTime() - startTime;
				var result = Convert.ToUInt32(Math.Abs(currTime.TotalSeconds));
				return result;
			}
		}

		public static ulong Hash
		{
			get
			{
				return (ulong)(((long)_random.Next(0, int.MaxValue) << 8) ^ (long)_random.Next(0, int.MaxValue));
			}
		}

		[JsonConstructor]
		public MongoId([JsonProperty("$value")] string id)
		{
			if (id == null || id.Length != 24)
			{
				throw new ArgumentOutOfRangeException($"Critical MongoId error: incorrect length. Id: {id}");
			}
			
            _timeStamp = GetTimestamp(id);
			_counter = GetCounter(id);

			GenerateNew();
		}

		public MongoId(bool newProcessId)
		{
            _timeStamp = 0U;

			if (newProcessId)
			{
				_counter = Hash << 24;
			}
			else
			{
				_newIdCounter += 1U;
				_counter = (_processId << 24) + (ulong)_newIdCounter;
			}

			_timeStamp = UnixTimestamp;
		}

		public MongoId(int accountId)
		{
			_timeStamp = UnixTimestamp;

			var num = Convert.ToUInt32(accountId);
			var num2 = Convert.ToUInt32(_random.Next(0, 16777215));

			_counter = 4294967296UL | (ulong)num;
			_counter <<= 24;
			_counter |= (ulong)num2;
		}

		public MongoId(MongoId source, int increment, bool newTimestamp = true)
		{
			if (newTimestamp)
			{
				_timeStamp = UnixTimestamp;
			}
			else
			{
				_timeStamp = source._timeStamp;
			}

			if (increment > 0)
			{
				_counter = source._counter + (ulong)Convert.ToUInt32(increment);
			}
			else
			{
				_counter = source._counter - (ulong)Convert.ToUInt32(Math.Abs(increment));
			}
		}

        // smethod_1
		public static uint GetTimestamp(string id)
		{
			return Convert.ToUInt32(id.Substring(0, 8), 16);
		}

        // smethod_2
		public static ulong GetCounter(string id)
		{
			return Convert.ToUInt64(id.Substring(8, 16), 16);
		}

        // method_0
		public void GenerateNew()
		{
			var num = Convert.ToUInt64(_counter >> 24);

			if (_processId != num)
			{
				return;
			}

			var num2 = Convert.ToUInt32(_counter << 40 >> 40);
			_newIdCounter = Math.Max(_newIdCounter, num2);
		}

		public bool Equals(MongoId other)
		{
			return _timeStamp == other._timeStamp
                && _counter == other._counter;
		}

		public int CompareTo(MongoId other)
		{
			if (this == other)
			{
				return 0;
			}

			if (this > other)
			{
				return 1;
			}

			return -1;
		}

		public override string ToString()
		{
			return _timeStamp.ToString("X8").ToLower()
                + _counter.ToString("X16").ToLower();
		}

		public override bool Equals(object obj)
		{
			if (obj != null)
			{
				if (obj is MongoId)
				{
					var mongoID = (MongoId)obj;
					return mongoID == this;
				}

				string text;

				if ((text = obj as string) != null)
				{
					return text == this.ToString();
				}
			}

			return false;
		}

		public override int GetHashCode()
		{
			var num = Convert.ToUInt32(_counter >> 32) * 3637U;
			var num2 = Convert.ToUInt32(_counter << 32 >> 32) * 5807U;

			return (int)(_timeStamp ^ num ^ num2);
		}

		public static implicit operator string(MongoId mongoId)
		{
			return mongoId.ToString();
		}

		public static implicit operator MongoId(string id)
		{
			return new MongoId(id);
		}

		public static bool operator ==(MongoId a, MongoId b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(MongoId a, MongoId b)
		{
			return !a.Equals(b);
		}

        public static bool operator >(MongoId a, MongoId b)
		{
			return a._timeStamp > b._timeStamp
                || (a._timeStamp == b._timeStamp && a._counter > b._counter);
		}

		public static bool operator <(MongoId a, MongoId b)
		{
			return a._timeStamp < b._timeStamp
                || (a._timeStamp == b._timeStamp && a._counter < b._counter);
		}

		public static bool operator >=(MongoId a, MongoId b)
		{
			return a == b || a > b;
		}

		public static bool operator <=(MongoId a, MongoId b)
		{
			return a == b || a < b;
		}
	}
}