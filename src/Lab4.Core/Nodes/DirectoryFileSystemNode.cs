using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class DirectoryFileSystemNode : IFileSystemNode
{
    private readonly Lazy<IReadOnlyCollection<IFileSystemNode>> _children;

    private readonly string _path;

    private readonly IFileSystem _fileSystem;

    public DirectoryFileSystemNode(
        string path,
        IFileSystem fileSystem)
    {
        _path = path;
        _children = new Lazy<IReadOnlyCollection<IFileSystemNode>>(LoadChildren);
        _fileSystem = fileSystem;
        Name = _fileSystem.GetFileName(_path);
    }

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemNode> Children => _children.Value;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    private List<IFileSystemNode> LoadChildren()
    {
        var result = _fileSystem.GetDirectories(_path).Select(directory => new DirectoryFileSystemNode(directory, _fileSystem)).Cast<IFileSystemNode>().ToList();
        result.AddRange(_fileSystem.GetFiles(_path).Select(file => new FileFileSystemNode(file)));

        return result;
    }
}