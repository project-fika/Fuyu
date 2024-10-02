using System;
using System.Text;
using Elskom.Generic.Libs;
using Zlib.Managed;

namespace ComponentAce.Compression.Libs.zlib
{
	public static class SimpleZlib
	{
        public const int bufsize = 4096;

		public static string Compress(string text, int compressLevel, Encoding encoding = null)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}

			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}

			var bytes = encoding.GetBytes(text);
			var deflated = MemoryZlib.Compress(bytes, (CompressionLevel)compressLevel);

			return encoding.GetString(deflated);
		}

		public static int CompressToBytesNonAlloc(string text, int compressLevel, byte[] encodingGetBytesBuffer, byte[] resultBuffer, Encoding encoding = null)
		{
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}

            _ = encoding.GetBytes(text, 0, text.Length, encodingGetBytesBuffer, 0);
			resultBuffer = MemoryZlib.Compress(encodingGetBytesBuffer, (CompressionLevel)compressLevel);

            return resultBuffer.Length;
		}

		public static byte[] CompressToBytes(string text, int compressLevel, Encoding encoding = null)
		{
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
    
			var bytes = encoding.GetBytes(text);

			return MemoryZlib.Compress(bytes, (CompressionLevel)compressLevel);
		}

		public static byte[] CompressToBytes(byte[] bytes, int length, int compressLevel)
		{
            return MemoryZlib.Compress(bytes, (CompressionLevel)compressLevel);
		}

        public static int CompressWithZStream(ref ZStream zstream, byte[] bytes, int startIndex, int length, byte[] compressedBytes, int compressLevel)
        {
            throw new NotImplementedException();
        }

		public static string Decompress(string compressed, Encoding encoding = null)
		{
			if (string.IsNullOrEmpty(compressed))
			{
				return string.Empty;
			}

			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}

			var bytes = encoding.GetBytes(compressed);
			var inflated = MemoryZlib.Decompress(bytes);

            return encoding.GetString(inflated);
		}

		public static string Decompress(byte[] bytes, Encoding encoding = null)
		{
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}

			var inflated = MemoryZlib.Decompress(bytes);

            return encoding.GetString(inflated);
		}

		public static byte[] DecompressToBytes(byte[] compressedBytes)
		{
			return MemoryZlib.Decompress(compressedBytes);
		}
	}
}