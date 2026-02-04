using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    FileSystemMoveResult MoveFile(string sourceAbsolutePath, string destinationAbsolutePath);

    FileSystemCopyResult CopyFile(string sourceAbsolutePath, string destinationAbsolutePath);

    FileSystemDeleteResult DeleteFile(string absolutePath);

    FileSystemShowResult ShowFile(string absolutePath, IWriter writer);

    FileSystemRenameResult RenameFile(string absolutePath, string newFileName);

    string GetFileName(string path);

    IEnumerable<string> GetFiles(string path);

    IEnumerable<string> GetDirectories(string path);

    string GetFullPath(string path);

    string GetFullPath(string path, string currentDirectory);

    bool IsFileExists(string path);

    bool IsDirectoryExists(string path);

    bool IsPathRooted(string path);

    bool IsPathFullyQualified(string path);
}