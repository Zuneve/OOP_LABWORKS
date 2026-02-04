using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

public record HandleResult
{
    private HandleResult() { }

    public sealed record Success(ICommandArgumentsBuilder Builder) : HandleResult;

    public sealed record Failed(IError Error) : HandleResult;
}