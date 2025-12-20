using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Models;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Operations;

public static class CreateUserSession
{
    public readonly record struct Request(long AccountId, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(UserSessionDto UserSessionDto) : Response;

        public sealed record Failed() : Response;
    }
}