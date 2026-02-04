using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Delete;

public class DeletePathHandler : BaseHandler
{
    private FileDeleteCommandArgumentsBuilder _fileDeleteCommandArgumentsBuilder;

    public DeletePathHandler(FileDeleteCommandArgumentsBuilder fileDeleteCommandArgumentsBuilder)
    {
        _fileDeleteCommandArgumentsBuilder = fileDeleteCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _fileDeleteCommandArgumentsBuilder = _fileDeleteCommandArgumentsBuilder.WithPath(iterator.Current);

        return new HandleResult.Success(_fileDeleteCommandArgumentsBuilder);
    }
}