using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ShowFileCommand : ICommand
{
    private readonly string _path;

    private readonly IWriter _writer;

    public ShowFileCommand(string path, IWriter writer)
    {
        _path = path;
        _writer = writer;
    }

    public CommandExecuteResult Execute(ConnectionContext connectionContext)
    {
        IFileSystem? fileSystem = connectionContext.FileSystem;

        return fileSystem is null
            ? new CommandExecuteResult.Failed(new FileSystemNotConnectedError())
            : fileSystem.ShowFile(_path, _writer) is FileSystemShowResult.Failed showFile
            ? new CommandExecuteResult.Failed(showFile.Error)
            : new CommandExecuteResult.Success();
    }
}