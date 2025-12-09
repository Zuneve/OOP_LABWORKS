using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeListCommand : ICommand
{
    private readonly IWriter _writer;

    private readonly int _maxDepth;

    private readonly TreeViewSymbolsSettings _treeViewSymbolsSettings;

    public TreeListCommand(
        IWriter writer,
        int maxDepth,
        TreeViewSymbolsSettings treeViewSymbolsSettings)
    {
        _writer = writer;
        _maxDepth = maxDepth;
        _treeViewSymbolsSettings = treeViewSymbolsSettings;
    }

    public CommandExecuteResult Execute(ConnectionContext connectionContext)
    {
        var fileSystemNodeCreator = new FileSystemNodeCreator();
        IFileSystemNode root = fileSystemNodeCreator.
            CreateFileSystemNode(connectionContext.CurrentDirectory);

        var visitor = new FileSystemNodeVisitor(
            _writer,
            _maxDepth,
            _treeViewSymbolsSettings);

        root.Accept(visitor);

        return new CommandExecuteResult.Success();
    }
}