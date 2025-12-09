using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public FileSystemMoveResult MoveFile(string sourceAbsolutePath, string destinationAbsolutePath)
    {
        if (!File.Exists(sourceAbsolutePath) || !Directory.Exists(destinationAbsolutePath))
        {
            return new FileSystemMoveResult.Failed(new FileNotFoundError());
        }

        File.Move(sourceAbsolutePath, destinationAbsolutePath, true);
        return new FileSystemMoveResult.Success();
    }

    public FileSystemCopyResult CopyFile(string sourceAbsolutePath, string destinationAbsolutePath)
    {
        if (!File.Exists(sourceAbsolutePath) || !Directory.Exists(destinationAbsolutePath))
        {
            return new FileSystemCopyResult.Failed(new FileNotFoundError());
        }

        File.Copy(sourceAbsolutePath, destinationAbsolutePath, true);
        return new FileSystemCopyResult.Success();
    }

    public FileSystemDeleteResult DeleteFile(string absolutePath)
    {
        if (!File.Exists(absolutePath))
        {
            return new FileSystemDeleteResult.Failed(new FileNotFoundError());
        }

        File.Delete(absolutePath);
        return new FileSystemDeleteResult.Success();
    }

    public FileSystemShowResult ShowFile(string absolutePath, IWriter writer)
    {
        if (!File.Exists(absolutePath))
        {
            return new FileSystemShowResult.Failed(new FileNotFoundError());
        }

        string content = File.ReadAllText(absolutePath);

        writer.Write(content);
        writer.Write("\n");
        return new FileSystemShowResult.Success();
    }

    public FileSystemRenameResult RenameFile(string absolutePath, string newFileName)
    {
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