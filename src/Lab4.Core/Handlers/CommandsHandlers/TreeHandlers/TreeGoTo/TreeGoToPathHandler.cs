using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.TreeCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.TreeHandlers.TreeGoTo;

public class TreeGoToPathHandler : BaseHandler
{
    private TreeGoToCommandArgumentsBuilder _treeGoToCommandArgumentsBuilder;

    public TreeGoToPathHandler(TreeGoToCommandArgumentsBuilder treeGoToCommandArgumentsBuilder)
    {
        _treeGoToCommandArgumentsBuilder = treeGoToCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _treeGoToCommandArgumentsBuilder = _treeGoToCommandArgumentsBuilder.WithPath(iterator.Current);

        return new HandleResult.Success(_treeGoToCommandArgumentsBuilder);
    }
}