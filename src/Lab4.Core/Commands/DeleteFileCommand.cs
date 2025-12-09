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

        PathResolverResult pathResolve = connectionContext.ResolvePath(_path);

        if (pathResolve is not PathResolverResult.Success pathResolveSuccess)
        {
            return new CommandExecuteResult.Failed(new FileNotFoundError());
        }

        string absolutePath = pathResolveSuccess.Path;

        return fileSystem is null
            ? new CommandExecuteResult.Failed(new FileSystemNotConnectedError())
            : fileSystem.DeleteFile(absolutePath) is FileSystemDeleteResult.Failed deleteFile
            ? new CommandExecuteResult.Failed(deleteFile.Error)
            : new CommandExecuteResult.Success();
    }
}