namespace Fuyu.Backend.Core.DTO.Accounts
{
    public enum ERegisterStatus
    {
        UsernameEmpty,
        UsernameTooLong,
        PasswordEmpty,
        PasswordTooShort,
        PasswordTooLong,
        AlreadyExists,
        Success
    }
}