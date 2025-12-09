using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    public ConnectCommand(string path)
    {
        _path = path;
    }

    private readonly string _path;

    public CommandExecuteResult Execute(ConnectionContext connectionContext)
    {
        IFileSystem? fileSystem = connectionContext.FileSystem;

        if (fileSystem is null)
        {
            return new CommandExecuteResult.Failed(new FileSystemNotConnectedError());
        }

        if (!Path.IsPathFullyQualified(_path))
        {
            return new CommandExecuteResult.Failed(new PathIsNotFullyQualifiedError());
        }

        connectionContext.SetCurrentDirectory(_path);

        return new CommandExecuteResult.Success();
    }
}