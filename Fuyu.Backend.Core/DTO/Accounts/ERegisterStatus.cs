namespace Fuyu.Backend.Core.DTO.Accounts
{
    public enum ERegisterStatus
    {
        UsernameEmpty,
        UsernameTooShort,
        UsernameTooLong,
        UsernameInvalid,
        PasswordEmpty,
        PasswordTooShort,
        PasswordTooLong,
        PasswordInvalid,
        AlreadyExists,
        Success
    }
}