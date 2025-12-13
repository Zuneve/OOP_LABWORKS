using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public class ConnectionContext
{
    private PathResolver _pathResolver;

    public ConnectionContext()
    {
        CurrentDirectory = string.Empty;
        _pathResolver = new PathResolver(null);
    }

    public string CurrentDirectory { get; private set; }

    public IFileSystem? FileSystem { get; private set; }

    public void Disconnect()
    {
        FileSystem = null;
        CurrentDirectory = string.Empty;
    }

    public void Connect(IFileSystem fileSystem, string path)
    {
        FileSystem = fileSystem;
        _pathResolver = new PathResolver(fileSystem);
        CurrentDirectory = path;
    }

    public PathResolverResult ResolvePath(string inputPath)
    {
        return _pathResolver.ResolvePath(CurrentDirectory, inputPath);
    }
}