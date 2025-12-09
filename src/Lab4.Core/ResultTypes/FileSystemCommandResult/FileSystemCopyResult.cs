using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;

public abstract record FileSystemCopyResult
{
    private FileSystemCopyResult() { }

    public sealed record Success() : FileSystemCopyResult;

    public sealed record Failed(IError Error) : FileSystemCopyResult;
}