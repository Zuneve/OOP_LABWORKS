using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;

public abstract record FileSystemRenameResult
{
    private FileSystemRenameResult() { }

    public sealed record Success() : FileSystemRenameResult;

    public sealed record Failed(IError Error) : FileSystemRenameResult;
}