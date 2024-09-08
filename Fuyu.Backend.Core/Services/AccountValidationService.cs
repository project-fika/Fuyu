using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core.Services
{
    // TODO:
        // * store max username length, min/max password length, security requirements in config
        // * validate username characters (only alphabetical, numbers)
        // * validate password characters (only alphabetical, numbers, some special characters)
        // -- seionmoya, 2024/09/08
    public static class AccountValidationService
    {
        private const int _maxUsernameLength = 15;
        private const int _maxPasswordLength = 32;
        private const int _minPasswordLength = 8;
        private static readonly char[] _lowerAlpha;
        private static readonly char[] _upperAlpha;
        private static readonly char[] _digit;
        private static readonly char[] _special;

        // NOTE: hardcoding the allowed characters for both more fine-grained
        //       control and easier to port to different languages (if there is
        //       need for this in the future).
        static AccountValidationService()
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

        public static ERegisterStatus ValidateUsername(string username)
        {
            if (username == string.Empty)
            {
                return ERegisterStatus.UsernameEmpty;
            }

            if (username.Length > _maxUsernameLength)
            {
                return ERegisterStatus.UsernameTooLong;
            }

            return ERegisterStatus.Success;
        }

        public static ERegisterStatus ValidatePassword(string password)
        {
            if (password == string.Empty)
            {
                return ERegisterStatus.PasswordEmpty;
            }

            if (password.Length < _minPasswordLength)
            {
                return ERegisterStatus.PasswordTooShort;
            }

            if (password.Length > _maxPasswordLength)
            {
                return ERegisterStatus.PasswordTooLong;
            }

            return ERegisterStatus.Success;
        }
    }
}