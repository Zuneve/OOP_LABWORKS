using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class MoveFileCommand : ICommand
{
    private readonly string _sourcePath;

    private readonly string _destinationPath;

    public MoveFileCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandExecuteResult Execute(ConnectionContext connectionContext)
    {
        IFileSystem? fileSystem = connectionContext.FileSystem;

        return fileSystem is null
            ? new CommandExecuteResult.Failed(new FileSystemNotConnectedError())
            : fileSystem.MoveFile(_sourcePath, _destinationPath) is FileSystemMoveResult.Failed moveFile
            ? new CommandExecuteResult.Failed(moveFile.Error)
            : new CommandExecuteResult.Success();
    }
}