using System.Text.RegularExpressions;
using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core.Services
{
    // TODO:
    // * store max username length, min/max password length, security requirements in config
    // -- seionmoya, 2024/09/08
    public static partial class AccountValidationService
    {
        private const int _minUsernameLength = 2;
        private const int _maxUsernameLength = 15;
        private const int _minPasswordLength = 8;
        private const int _maxPasswordLength = 32;

        // compile-time generated regex
        // `(?=.*?[A-Z])`:          is at least one uppercase alpha present
        // `(?=.*?[a-z])`:          is at least one lowercase alpha present
        // `(?=.*?[0-9])`:          is at least one digit present
        // `{2,15}`:                length must be between 2 to 15
        [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{2,15}$")]
        private static partial Regex UsernameRegex();

        // compile-time generated regex
        // `(?=.*?[A-Z])`:          is at least one uppercase alpha present
        // `(?=.*?[a-z])`:          is at least one lowercase alpha present
        // `(?=.*?[0-9])`:          is at least one digit present
        // `(?=.*?[#?!@$%^&*-])`:   is at least one special character present
        // `{8,32}`:                length must be between 8 to 32
        [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,32}$")]
        private static partial Regex PasswordRegex();

        public static ERegisterStatus ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return ERegisterStatus.UsernameEmpty;
            }

            // check character length
            if (username.Length < _minUsernameLength)
            {
                return ERegisterStatus.UsernameTooLong;
            }

            if (username.Length > _maxUsernameLength)
            {
                return ERegisterStatus.UsernameTooLong;
            }

            if (!UsernameRegex().IsMatch(username))
            {
                return ERegisterStatus.UsernameInvalid;
            }

            return ERegisterStatus.Success;
        }

        public static ERegisterStatus ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
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

            if (!PasswordRegex().IsMatch(password))
            {
                return ERegisterStatus.PasswordInvalid;
            }

            return ERegisterStatus.Success;
        }
    }
} 