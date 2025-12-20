using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Models;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Operations;

public static class CreateAdminSession
{
    public readonly record struct Request(string InputPassword);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AdminSessionDto AdminSession) : Response;

        public sealed record Failed() : Response;
    }
}