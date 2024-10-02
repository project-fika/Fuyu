using System;

namespace Elskom.Generic.Libs
{
    internal static class Adler32
    {
        // largest prime smaller than 65536
        private const int BASE = 65521;

        // NMAX is the largest n such that 255n(n+1)/2 + (n+1)(BASE-1) <= 2^32-1
        private const int NMAX = 5552;

        public static long Calculate(long adler, ReadOnlySpan<byte> buffer, int index, int length)
        {
            if (buffer == null)
            {
                return 1L;
            }

            var s1 = adler & 0xFFFF;
            var s2 = (adler >> 16) & 0xFFFF;
            int k;

            while (length > 0)
            {
                k = length < NMAX ? length : NMAX;
                length -= k;

                while (k >= 16)
                {
                    for (var i = 0; i < 16; ++i)
                    {
                        s1 += buffer[index++] & 0xFF;
                        s2 += s1;
                    }

                    k -= 16;
                }

                if (k != 0)
                {
                    do
                    {
                        s1 += buffer[index++] & 0xFF;
                        s2 += s1;
                    }
                    while (--k != 0);
                }

                s1 %= BASE;
                s2 %= BASE;
            }

            return (s2 << 16) | s1;
        }
    }
}