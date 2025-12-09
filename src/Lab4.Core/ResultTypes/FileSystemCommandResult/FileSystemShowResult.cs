using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;

public abstract record FileSystemShowResult
{
    private FileSystemShowResult() { }

    public sealed record Success() : FileSystemShowResult;

    public sealed record Failed(IError Error) : FileSystemShowResult;
}