using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;

public abstract record FileSystemDeleteResult
{
    private FileSystemDeleteResult() { }

    public sealed record Success() : FileSystemDeleteResult;

    public sealed record Failed(IError Error) : FileSystemDeleteResult;
}