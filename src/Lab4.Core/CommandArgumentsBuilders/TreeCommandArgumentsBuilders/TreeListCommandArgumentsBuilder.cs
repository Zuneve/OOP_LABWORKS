using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.TreeCommandArgumentsBuilders;

public class TreeListCommandArgumentsBuilder : ICommandArgumentsBuilder
{
    private int _maxDepth = 1;

    private IWriter _writer = new ConsoleWriter();

    private TreeViewSymbolsSettings _treeViewSymbolsSettings = new TreeViewSymbolsSettings();

    public TreeListCommandArgumentsBuilder WithMaxDepth(int maxDepth)
    {
        _maxDepth = maxDepth;
        return this;
    }

    public TreeListCommandArgumentsBuilder WithWriter(IWriter writer)
    {
        _writer = writer;
        return this;
    }

    public TreeListCommandArgumentsBuilder WithTreeViewSymbolSettings(TreeViewSymbolsSettings treeViewSymbolsSettings)
    {
        _treeViewSymbolsSettings = treeViewSymbolsSettings;
        return this;
    }

    public CommandArgumentsBuilderResult Build()
    {
        return new CommandArgumentsBuilderResult.Success(
            new TreeListCommand(
                _writer,
                _maxDepth,
                _treeViewSymbolsSettings));
    }
}