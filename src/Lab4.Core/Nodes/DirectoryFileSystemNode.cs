using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class DirectoryFileSystemNode : IFileSystemNode
{
    private readonly Lazy<IReadOnlyCollection<IFileSystemNode>> _children;

    private readonly string _path;

    public DirectoryFileSystemNode(
        string path)
    {
        _path = path;
        Name = Path.GetFileName(path);
        _children = new Lazy<IReadOnlyCollection<IFileSystemNode>>(LoadChildren);
    }

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemNode> Children => _children.Value;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    private List<IFileSystemNode> LoadChildren()
    {
        var result = new List<IFileSystemNode>();

        foreach (string directory in Directory.GetDirectories(_path))
        {
            result.Add(new DirectoryFileSystemNode(directory));
        }

        foreach (string file in Directory.GetFiles(_path))
        {
            result.Add(new FileFileSystemNode(file));
        }

        return result;
    }
}