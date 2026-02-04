using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class DirectoryFileSystemNode : IFileSystemNode
{
    private readonly string _path;

    private readonly IFileSystem _fileSystem;

    public DirectoryFileSystemNode(
        string path,
        IFileSystem fileSystem)
    {
        _path = path;
        _fileSystem = fileSystem;
        Name = _fileSystem.GetFileName(_path);
    }

    public string Name { get; }

    public IEnumerable<IFileSystemNode> Children => LoadChildren();

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    private IEnumerable<IFileSystemNode> LoadChildren()
    {
        foreach (DirectoryFileSystemNode node in _fileSystem.GetDirectories(_path).Select(directory => new DirectoryFileSystemNode(directory, _fileSystem)))
        {
            yield return node;
        }

        foreach (FileFileSystemNode node in _fileSystem.GetFiles(_path).Select(file => new FileFileSystemNode(file)))
        {
            yield return node;
        }
    }
}