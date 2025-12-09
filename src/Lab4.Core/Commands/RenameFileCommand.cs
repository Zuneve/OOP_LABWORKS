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

        return fileSystem is null
            ? new CommandExecuteResult.Failed(new FileSystemNotConnectedError())
            : fileSystem.RenameFile(_path, _newFileName) is FileSystemRenameResult.Failed renameFile
            ? new CommandExecuteResult.Failed(renameFile.Error)
            : new CommandExecuteResult.Success();
    }
}