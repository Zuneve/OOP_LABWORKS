namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;

public static class ShowBalanceAccount
{
    public readonly record struct Request(Guid SessionId);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(decimal Balance) : Response;

        public sealed record Failed() : Response;
    }
}