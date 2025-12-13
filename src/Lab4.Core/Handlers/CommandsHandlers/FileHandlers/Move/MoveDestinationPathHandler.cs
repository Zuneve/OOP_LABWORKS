using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Move;

public class MoveDestinationPathHandler : BaseHandler
{
    private FileMoveCommandArgumentsBuilder _fileMoveCommandArgumentsBuilder;

    public MoveDestinationPathHandler(FileMoveCommandArgumentsBuilder fileMoveCommandArgumentsBuilder)
    {
        _fileMoveCommandArgumentsBuilder = fileMoveCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _fileMoveCommandArgumentsBuilder = _fileMoveCommandArgumentsBuilder.WithDestinationPath(iterator.Current);

        return new HandleResult.Success(_fileMoveCommandArgumentsBuilder);
    }
}