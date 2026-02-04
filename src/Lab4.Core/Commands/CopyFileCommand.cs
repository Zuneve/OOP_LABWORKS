using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class CopyFileCommand : ICommand
{
    private readonly string _sourcePath;

    private readonly string _destinationPath;

    public CopyFileCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandExecuteResult Execute(ConnectionContext connectionContext)
    {
        IFileSystem? fileSystem = connectionContext.FileSystem;

        if (fileSystem is null)
        {
            return new CommandExecuteResult.Failed(new FileSystemNotConnectedError());
        }

        PathResolverResult sourcePathResolve = connectionContext.ResolvePath(_sourcePath);
        PathResolverResult destinationPathResolve = connectionContext.ResolvePath(_destinationPath);

        if (sourcePathResolve is not PathResolverResult.Success sourcePathResolveSuccess
            || destinationPathResolve is not PathResolverResult.Success destinationPathResolveSuccess)
        {
            return new CommandExecuteResult.Failed(new FileNotFoundError());
        }

        string sourceAbsolutePath = sourcePathResolveSuccess.Path;
        string destinationAbsolutePath = destinationPathResolveSuccess.Path;

        if (fileSystem.CopyFile(sourceAbsolutePath, destinationAbsolutePath) is FileSystemCopyResult.Failed)
        {
            return new CommandExecuteResult.Failed(new FileNotFoundError());
        }

        return new CommandExecuteResult.Success();
    }
}