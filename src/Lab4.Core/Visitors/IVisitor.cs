using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

public interface IVisitor
{
    void Visit(DirectoryFileSystemNode directoryFileSystemNode);

    void Visit(FileFileSystemNode fileFileSystemNode);
}