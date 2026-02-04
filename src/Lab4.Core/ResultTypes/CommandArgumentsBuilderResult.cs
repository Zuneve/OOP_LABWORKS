using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

public abstract record CommandArgumentsBuilderResult
{
    private CommandArgumentsBuilderResult() { }

    public sealed record Success(ICommand Command) : CommandArgumentsBuilderResult;

    public sealed record Failed(IError Error) : CommandArgumentsBuilderResult;
}