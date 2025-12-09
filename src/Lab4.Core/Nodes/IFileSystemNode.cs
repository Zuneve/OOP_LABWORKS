using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public interface IFileSystemNode
{
    string Name { get; }

    void Accept(IVisitor visitor);
}