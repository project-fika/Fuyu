namespace Fuyu.Backend.Core.Services
{
    public static class TextService
    {
        private static readonly char[] _lowerAlpha;
        private static readonly char[] _upperAlpha;
        private static readonly char[] _digit;
        private static readonly char[] _special;

        // NOTE: hardcoding the allowed characters for both more fine-grained
        //       control and easier to port to different languages (if there is
        //       need for this in the future).
        static TextService()
        {
            _lowerAlpha =
            [
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z'
            ];
            _upperAlpha =
            [
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                'Y', 'Z'
            ];
            _digit =
            [
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            ];
            _special =
            [
                '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+',
                '_', '=', '`', '~', '[', ']', '{', '}', ';', ':', '|', '<',
                ',', '>', '.', '/', '?'
            ];
        }

        private static bool IsMatch(char[] chars, char c)
        {
            foreach (var entry in chars)
            {
                if (entry == c)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsMatch(char[] chars, string text)
        {
            foreach (var c in text)
            {
                if (IsMatch(chars, c))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsLowerAlpha(char c)
        {
            return IsMatch(_lowerAlpha, c);
        }

        public static bool IsUpperAlpha(char c)
        {
            return IsMatch(_upperAlpha, c);
        }

        public static bool IsDigit(char c)
        {
            return IsMatch(_digit, c);
        }

        public static bool IsSpecial(char c)
        {
            return IsMatch(_special, c);
        }

        public static bool ContainsLowerAlpha(string text)
        {
            return IsMatch(_lowerAlpha, text);
        }

        public static bool ContainsUpperAlpha(string text)
        {
            return IsMatch(_upperAlpha, text);
        }

        public static bool ContainsDigit(string text)
        {
            return IsMatch(_digit, text);
        }

        public static bool ContainsSpecial(string text)
        {
            return IsMatch(_special, text);
        }
    }
}