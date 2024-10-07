using System;
using System.Text;

namespace ComponentAce.Compression.Libs.zlib
{
	// NOTE: hollowed type
    // -- seionmoya, 2024-10-07
	public static class SimpleZlib
	{
		public static string Compress(string text, int compressLevel, Encoding encoding = null)
		{
			throw new NotImplementedException();
		}

		public static int CompressToBytesNonAlloc(string text, int compressLevel, byte[] encodingGetBytesBuffer, byte[] resultBuffer, Encoding encoding = null)
		{
			throw new NotImplementedException();
		}

		public static byte[] CompressToBytes(string text, int compressLevel, Encoding encoding = null)
		{
			throw new NotImplementedException();
		}

		public static byte[] CompressToBytes(byte[] bytes, int length, int compressLevel)
		{
            throw new NotImplementedException();
		}

        public static int CompressWithZStream(ref ZStream zstream, byte[] bytes, int startIndex, int length, byte[] compressedBytes, int compressLevel)
        {
            throw new NotImplementedException();
        }

		public static string Decompress(string compressed, Encoding encoding = null)
		{
			throw new NotImplementedException();
		}

		public static string Decompress(byte[] bytes, Encoding encoding = null)
		{
			throw new NotImplementedException();
		}

		public static byte[] DecompressToBytes(byte[] compressedBytes)
		{
			throw new NotImplementedException();
		}
	}
}