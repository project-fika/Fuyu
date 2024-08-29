using System;
using System.Text;

namespace Fuyu.Platform.Common.Hashing
{
    public static class EftHash
    {
        private static readonly Random _random;
        private static readonly char[] _chars;

        static EftHash()
        {
            _random = new Random();

            // Using array instead of C#'s functions due to culture variance.
            _chars = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
        }

        public static string Generate(int length = 24)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < length; ++i)
            {
                var index = _random.Next(0, _chars.Length);
                sb.Append(_chars[index]);
            }

            return sb.ToString();
        }
    }
}
