using Itmo.ObjectOrientedProgramming.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Operations;

public static class CreateUserSession
{
    public readonly record struct Request(Guid AccountId, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(UserSession UserSession) : Response;

        public sealed record Failed() : Response;
    }
}