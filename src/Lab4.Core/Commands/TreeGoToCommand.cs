using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly string _path;

    public TreeGoToCommand(string path)
    {
        _path = path;
    }

    public CommandExecuteResult Execute(ConnectionContext connectionContext)
    {
        IFileSystem? fileSystem = connectionContext.FileSystem;

        if (fileSystem is null)
        {
            return new CommandExecuteResult.Failed(new FileSystemNotConnectedError());
        }

        PathResolverResult resolverResult = connectionContext.ResolvePath(_path);

        if (resolverResult is not PathResolverResult.Success result
            || fileSystem.IsDirectoryExists(result.Path))
        {
            return new CommandExecuteResult.Failed(new DirectoryNotFoundError());
        }

        connectionContext.SetCurrentDirectory(result.Path);

        return new CommandExecuteResult.Success();
    }
}