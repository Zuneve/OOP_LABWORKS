namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class FileSystemNodeCreator
{
    public IFileSystemNode CreateFileSystemNode(string path)
    {
        if (!Directory.Exists(path)) return new FileFileSystemNode(path);

        var children = Directory.GetDirectories(path).Select(CreateFileSystemNode).ToList();
        children.AddRange(Directory.GetFiles(path).Select(file => new FileFileSystemNode(file)));

        return new DirectoryFileSystemNode(path, children);
    }
}