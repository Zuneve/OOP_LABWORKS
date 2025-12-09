using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.TreeHandlers;

public class TreeListHandler : BaseHandler
{
    private readonly IWriter _writer;

    private readonly TreeViewSymbolsSettings _treeViewSymbolsSettings;

    public TreeListHandler(
        IWriter writer,
        TreeViewSymbolsSettings treeViewSymbolsSettings)
    {
        _writer = writer;
        _treeViewSymbolsSettings = treeViewSymbolsSettings;
    }

    public override ICommand? Handle(CommandOptions commandOptions)
    {
        IList<string> parameters = commandOptions.Parameters;

        IReadOnlyDictionary<string, string> flags = commandOptions.Flags;

        if (parameters.Count < 2 || parameters[0] != "tree" || parameters[1] != "list")
        {
            return Next?.Handle(commandOptions);
        }

        if (!flags.TryGetValue("-d", out string? depthStr) || !int.TryParse(depthStr, out int depth))
        {
            depth = 1;
        }

        return new TreeListCommand(_writer, depth, _treeViewSymbolsSettings);
    }
}