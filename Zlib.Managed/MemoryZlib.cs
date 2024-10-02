// ZOutputStream.Close() flushes itself.
// ZOutputStream.Flush() flushes the target stream.
// -- Waffle.Lord, 2022-12-01

using System;
using System.IO;
using Elskom.Generic.Libs;

namespace Zlib.Managed
{
    public static class MemoryZlib
    {
        public static bool IsCompressed(byte[] data)
        {
            if (data == null || data.Length < 3)
            {
                return false;
            }

            // data[0]: Info (CM/CINFO) Header; must be 0x78
            if (data[0] != 0x78)
            {
                return false;
            }

            // data[1]: Flags (FLG) Header; compression level.
            switch (data[1])
            {
                case 0x01:  // lowest   (0-2)
                case 0x5E:  // low      (3-4)
                case 0x9C:  // normal   (5-6)
                case 0xDA:  // high     (7-9)
                    return true;

                default:    // no match
                    return false;
            }
        }

        public static byte[] Compress(byte[] data, CompressionLevel level)
        {
            if (level == CompressionLevel.NoCompression)
            {
                throw new ArgumentException("level cannot be ZlibCompression.NoCompression");
            }

            using (var ms = new MemoryStream())
            {
                using (var zs = new ZOutputStream(ms, level))
                {
                    zs.Write(data, 0, data.Length);
                }
                // <-- zs flushes everything here

                return ms.ToArray();
            }
        }

        public static byte[] Decompress(byte[] data)
        {
            using (var ms = new MemoryStream())
            {
                using (var zs = new ZOutputStream(ms))
                {
                    zs.Write(data, 0, data.Length);
                }
                // <-- zs flushes everything here

                return ms.ToArray();
            }
        }
    }
}