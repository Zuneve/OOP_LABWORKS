using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

public abstract record CommandExecuteResult
{
    private CommandExecuteResult() { }

    public sealed record Success() : CommandExecuteResult;

    public sealed record Failed(IError Error) : CommandExecuteResult;
}