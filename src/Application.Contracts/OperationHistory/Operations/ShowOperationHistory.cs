using Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory.Models;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory.Operations;

public class ShowOperationHistory
{
    public readonly record struct Request(Guid SessionId);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(IReadOnlyCollection<OperationDto> OperationHistory) : Response;

        public sealed record Failed() : Response;
    }
}