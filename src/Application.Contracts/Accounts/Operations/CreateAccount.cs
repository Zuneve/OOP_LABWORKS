using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Models;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;

public static class CreateAccount
{
    public readonly record struct Request(Guid SessionId, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AccountDto AccountDto) : Response;

        public sealed record Failed() : Response;
    }
}