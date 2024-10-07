using System;
using System.IO;
using System.IO.Compression;
using ComponentAce.Compression.Libs.zlib;

namespace Fuyu.Compression
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
#if NET6_0_OR_GREATER
            using (var msin = new MemoryStream(data))
            {
                using (var msout = new MemoryStream())
                {
                    using (var zs = new ZLibStream(msout, level))
                    {
                        msin.CopyTo(zs);
                        zs.Flush();
                        return msout.ToArray();
                    }
                }
            }
#else
            // NOTE: assumes this is running in EFT
            // -- seionmoya, 2024-10-07
            var compressLevel = 0;

            switch (level)
            {
                case CompressionLevel.NoCompression:
                    throw new Exception("CompressToBytes does not support level 0");

                case CompressionLevel.Fastest:
                    compressLevel = 1;
                    break;

                // NOTE: CompressionLevel.SmallestSize does not exist in
                //       .NET 5 and below.
                // -- seionmoya, 2024-10-07
                case CompressionLevel.Optimal:
                    compressLevel = 9;
                    break;
            }

            return SimpleZlib.CompressToBytes(data, data.Length, compressLevel);
#endif
        }

        public static byte[] Decompress(byte[] data)
        {
#if NET6_0_OR_GREATER
            using (var msin = new MemoryStream(data))
            {
                using (var msout = new MemoryStream())
                {
                    using (var zs = new ZLibStream(msin, CompressionMode.Decompress))
                    {
                        zs.CopyTo(msout);
                        return msout.ToArray();
                    }
                }
            }
#else
            // NOTE: assumes this is running in EFT
            // -- seionmoya, 2024-10-07
            return SimpleZlib.DecompressToBytes(data);
#endif
        }
    }
}