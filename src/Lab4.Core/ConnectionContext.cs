using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public class ConnectionContext
{
    private readonly PathResolver _pathResolver;

    public ConnectionContext(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
        CurrentDirectory = string.Empty;
        _pathResolver = new PathResolver();
    }

    public ConnectionContext()
    {
        CurrentDirectory = string.Empty;
        _pathResolver = new PathResolver();
    }

    public string CurrentDirectory { get; private set; }

    public IFileSystem? FileSystem { get; private set; }

    public void Clear()
    {
        FileSystem = null;
    }

    public void SetCurrentDirectory(string path)
    {
        CurrentDirectory = path;
    }

    public void SetFileSystem(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public PathResolverResult ResolvePath(string inputPath)
    {
        return _pathResolver.ResolvePath(CurrentDirectory, inputPath);
    }
}