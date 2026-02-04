using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public class PathResolver
{
    private readonly IFileSystem? _fileSystem;

    public PathResolver(IFileSystem? fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public PathResolverResult ResolvePath(string currentDirectory, string inputPath)
    {
        if (_fileSystem is null || string.IsNullOrWhiteSpace(inputPath))
        {
            return new PathResolverResult.Failed(new EmptyPathError());
        }

        if (_fileSystem.IsPathRooted(inputPath))
        {
            return new PathResolverResult.Success(_fileSystem.GetFullPath(inputPath));
        }

        return new PathResolverResult.Success(_fileSystem.GetFullPath(inputPath, currentDirectory));
    }
}