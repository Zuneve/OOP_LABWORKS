using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

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

        fileSystem.RenameFile(_path, _newFileName);

        return new CommandExecuteResult.Success();
    }
}