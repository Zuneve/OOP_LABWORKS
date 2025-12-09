using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private readonly ConnectionContext _connectionContext;

    public LocalFileSystem(ConnectionContext connectionContext)
    {
        _connectionContext = connectionContext;
    }

    public FileSystemMoveResult MoveFile(string sourcePath, string destinationPath)
    {
        PathResolverResult sourcePathResolve = _connectionContext.ResolvePath(sourcePath);
        PathResolverResult destinationPathResolve = _connectionContext.ResolvePath(destinationPath);

        if (sourcePathResolve is not PathResolverResult.Success sourcePathResolveSuccess
            || destinationPathResolve is not PathResolverResult.Success destinationPathResolveSuccess)
        {
            return new FileSystemMoveResult.Failed(new FileNotFoundError());
        }

        string sourceAbsolutePath = sourcePathResolveSuccess.Path;
        string destinationAbsolutePath = destinationPathResolveSuccess.Path;

        if (!File.Exists(sourceAbsolutePath) || !Directory.Exists(destinationAbsolutePath))
        {
            return new FileSystemMoveResult.Failed(new FileNotFoundError());
        }

        File.Move(sourceAbsolutePath, destinationAbsolutePath, true);
        return new FileSystemMoveResult.Success();
    }

    public FileSystemCopyResult CopyFile(string sourcePath, string destinationPath)
    {
        PathResolverResult sourcePathResolve = _connectionContext.ResolvePath(sourcePath);
        PathResolverResult destinationPathResolve = _connectionContext.ResolvePath(destinationPath);

        if (sourcePathResolve is not PathResolverResult.Success sourcePathResolveSuccess
            || destinationPathResolve is not PathResolverResult.Success destinationPathResolveSuccess)
        {
            return new FileSystemCopyResult.Failed(new FileNotFoundError());
        }

        string sourceAbsolutePath = sourcePathResolveSuccess.Path;
        string destinationAbsolutePath = destinationPathResolveSuccess.Path;

        if (!File.Exists(sourceAbsolutePath) || !Directory.Exists(destinationAbsolutePath))
        {
            return new FileSystemCopyResult.Failed(new FileNotFoundError());
        }

        File.Copy(sourceAbsolutePath, destinationAbsolutePath, true);
        return new FileSystemCopyResult.Success();
    }

    public FileSystemDeleteResult DeleteFile(string path)
    {
        PathResolverResult pathResolve = _connectionContext.ResolvePath(path);

        if (pathResolve is not PathResolverResult.Success pathResolveSuccess)
        {
            return new FileSystemDeleteResult.Failed(new FileNotFoundError());
        }

        string absolutePath = pathResolveSuccess.Path;

        if (!File.Exists(absolutePath))
        {
            return new FileSystemDeleteResult.Failed(new FileNotFoundError());
        }

        File.Delete(absolutePath);
        return new FileSystemDeleteResult.Success();
    }

    public FileSystemShowResult ShowFile(string path, IWriter writer)
    {
        PathResolverResult pathResolve = _connectionContext.ResolvePath(path);

        if (pathResolve is not PathResolverResult.Success pathResolveSuccess)
        {
            return new FileSystemShowResult.Failed(new FileNotFoundError());
        }

        string absolutePath = pathResolveSuccess.Path;

        if (!File.Exists(absolutePath))
        {
            return new FileSystemShowResult.Failed(new FileNotFoundError());
        }

        string content = File.ReadAllText(absolutePath);

        writer.Write(content);
        writer.Write("\n");
        return new FileSystemShowResult.Success();
    }

    public FileSystemRenameResult RenameFile(string path, string newFileName)
    {
        PathResolverResult pathResolve = _connectionContext.ResolvePath(path);

        if (pathResolve is not PathResolverResult.Success pathResolveSuccess)
        {
            return new FileSystemRenameResult.Failed(new FileNotFoundError());
        }

        string absolutePath = pathResolveSuccess.Path;

        if (!File.Exists(absolutePath))
        {
            return new FileSystemRenameResult.Failed(new FileNotFoundError());
        }

        string? directory = Path.GetDirectoryName(absolutePath);
        if (directory is null)
        {
            return new FileSystemRenameResult.Failed(new FileNotFoundError());
        }

        string newFilePath = Path.Combine(directory, newFileName);
        File.Move(absolutePath, newFilePath);

        return new FileSystemRenameResult.Success();
    }
}