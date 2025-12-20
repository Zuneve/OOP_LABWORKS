using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Models;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;

public static class CreateAccount
{
    public readonly record struct Request(Guid SessionId, string PinCode);

    public readonly record struct Response(AccountDto Account);
}