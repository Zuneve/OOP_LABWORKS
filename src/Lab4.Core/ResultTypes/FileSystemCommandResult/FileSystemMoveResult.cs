using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;

public abstract record FileSystemMoveResult
{
    private FileSystemMoveResult() { }

    public sealed record Success() : FileSystemMoveResult;

    public sealed record Failed(IError Error) : FileSystemMoveResult;
}