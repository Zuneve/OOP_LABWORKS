using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

public abstract record PathResolverResult
{
    private PathResolverResult() { }

    public sealed record Success(string Path) : PathResolverResult;

    public sealed record Failed(IError Error) : PathResolverResult;
}