using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class RenameFileCommand : ICommand
{
    private readonly string _path;

    private readonly string _newFileName;

    public RenameFileCommand(string path, string newFileName)
    {
        _path = path;
        _newFileName = newFileName;
    }

    public CommandExecuteResult Execute(ConnectionContext connectionContext)
    {
        IFileSystem? fileSystem = connectionContext.FileSystem;

        if (fileSystem is null)
        {
            return new CommandExecuteResult.Failed(new FileSystemNotConnectedError());
        }

        PathResolverResult pathResolve = connectionContext.ResolvePath(_path);

        if (pathResolve is not PathResolverResult.Success pathResolveSuccess)
        {
            return new CommandExecuteResult.Failed(new FileNotFoundError());
        }

        string absolutePath = pathResolveSuccess.Path;

        if (fileSystem.RenameFile(absolutePath, _newFileName) is FileSystemRenameResult.Failed)
        {
            return new CommandExecuteResult.Failed(new FileNotFoundError());
        }

        return new CommandExecuteResult.Success();
    }
}