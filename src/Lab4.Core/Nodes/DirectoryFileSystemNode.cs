using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class DirectoryFileSystemNode : IFileSystemNode
{
    public DirectoryFileSystemNode(
        string name,
        IReadOnlyCollection<IFileSystemNode> children)
    {
        Name = name;
        Children = new Lazy<IReadOnlyCollection<IFileSystemNode>>(children);
    }

    public string Name { get; }

    public Lazy<IReadOnlyCollection<IFileSystemNode>> Children { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}