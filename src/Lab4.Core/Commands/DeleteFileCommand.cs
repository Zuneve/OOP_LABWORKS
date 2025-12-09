using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DeleteFileCommand : ICommand
{
    private readonly string _path;

    public DeleteFileCommand(string path)
    {
        _path = path;
    }

    public CommandExecuteResult Execute(ConnectionContext connectionContext)
    {
        IFileSystem? fileSystem = connectionContext.FileSystem;

        return fileSystem is null
            ? new CommandExecuteResult.Failed(new FileSystemNotConnectedError())
            : fileSystem.DeleteFile(_path) is FileSystemDeleteResult.Failed deleteFile
            ? new CommandExecuteResult.Failed(deleteFile.Error)
            : new CommandExecuteResult.Success();
    }
}