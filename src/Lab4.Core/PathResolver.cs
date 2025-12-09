using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public class PathResolver
{
    public PathResolverResult ResolvePath(string currentDirectory, string inputPath)
    {
        return string.IsNullOrWhiteSpace(inputPath)
            ? new PathResolverResult.Failed(new EmptyPathError())
            : Path.IsPathRooted(inputPath)
            ? new PathResolverResult.Success(Path.GetFullPath(inputPath))
            : new PathResolverResult.Success(Path.GetFullPath(inputPath, currentDirectory));
    }
}