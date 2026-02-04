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

        if (fileSystem.ShowFile(absolutePath, _writer) is FileSystemShowResult.Success showFile)
        {
            _writer.Write(showFile.Text);

            return new CommandExecuteResult.Success();
        }

        return new CommandExecuteResult.Failed(new FileNotFoundError());
    }
}