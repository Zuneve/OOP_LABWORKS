using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class FileFileSystemNode : IFileSystemNode
{
    public FileFileSystemNode(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}