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

            for (var i = 0; i < username.Length; ++i)
            {
                var c = username[i];

                if (!TextService.IsLowerAlpha(c)
                    && !TextService.IsUpperAlpha(c)
                    && !TextService.IsDigit(c))
                {
                    return ERegisterStatus.UsernameInvalidCharacter;
                }
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

            // check character presence
            if (!TextService.ContainsLowerAlpha(password)
                || !TextService.ContainsUpperAlpha(password)
                || !TextService.ContainsDigit(password)
                || !TextService.ContainsSpecial(password))
            {
                return ERegisterStatus.PasswordInvalidCharacter;
            }

            // check invalid characters
            for (var i = 0; i < password.Length; ++i)
            {
                var c = password[i];

                if (!TextService.IsLowerAlpha(c)
                    && !TextService.IsUpperAlpha(c)
                    && !TextService.IsDigit(c)
                    && !TextService.IsSpecial(c))
                {
                    return ERegisterStatus.PasswordInvalidCharacter;
                }
            }

            return ERegisterStatus.Success;
        }
    }
}