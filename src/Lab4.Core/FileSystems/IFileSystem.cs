using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.FileSystemCommandResult;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    FileSystemMoveResult MoveFile(string sourcePath, string destinationPath);

    FileSystemCopyResult CopyFile(string sourcePath, string destinationPath);

    FileSystemDeleteResult DeleteFile(string path);

    FileSystemShowResult ShowFile(string path, IWriter writer);

    FileSystemRenameResult RenameFile(string path, string newFileName);
}