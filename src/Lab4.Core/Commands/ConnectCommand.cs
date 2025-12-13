using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _path;

    private readonly IFileSystem _fileSystem;

    public ConnectCommand(string path, IFileSystem fileSystem)
    {
        _path = path;
        _fileSystem = fileSystem;
    }

    public CommandExecuteResult Execute(ConnectionContext connectionContext)
    {
        if (!connectionContext.IsPathFullyQualified(_path))
        {
            return new CommandExecuteResult.Failed(new PathIsNotFullyQualifiedError());
        }

        connectionContext.SetCurrentDirectory(_path);
        connectionContext.SetFileSystem(_fileSystem);

        return new CommandExecuteResult.Success();
    }
}