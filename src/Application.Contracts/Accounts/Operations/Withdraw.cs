namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;

public static class Withdraw
{
    public readonly record struct Request(Guid SessionId, decimal Amount);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(decimal NewBalance) : Response;

        public sealed record Failed() : Response;
    }
}