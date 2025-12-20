namespace Itmo.ObjectOrientedProgramming.Application.Security;

public sealed class AdminPassword
{
    private readonly string _password;

    public AdminPassword(string password)
    {
        _password = password;
    }

    public bool IsEqual(string inputPassword)
    {
        return _password == inputPassword;
    }
}