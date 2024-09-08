namespace Fuyu.Backend.Core.DTO.Accounts
{
    public enum ERegisterStatus
    {
        UsernameEmpty,
        UsernameTooLong,
        UsernameInvalidCharacter,
        PasswordEmpty,
        PasswordTooShort,
        PasswordTooLong,
        PasswordInvalidCharacter,
        AlreadyExists,
        Success
    }
}