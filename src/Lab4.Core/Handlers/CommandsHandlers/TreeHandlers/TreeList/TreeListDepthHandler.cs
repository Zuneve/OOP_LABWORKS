using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.TreeCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.TreeHandlers.TreeList;

public class TreeListDepthHandler : BaseHandler
{
    private TreeListCommandArgumentsBuilder _treeListCommandArgumentsBuilder;

    public TreeListDepthHandler(TreeListCommandArgumentsBuilder treeListCommandArgumentsBuilder)
    {
        _treeListCommandArgumentsBuilder = treeListCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _treeListCommandArgumentsBuilder = _treeListCommandArgumentsBuilder.WithMaxDepth(int.Parse(iterator.Current));

        return new HandleResult.Success(_treeListCommandArgumentsBuilder);
    }
}