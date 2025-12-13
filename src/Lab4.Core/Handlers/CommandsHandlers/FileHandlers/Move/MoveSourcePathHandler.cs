using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Move;

public class MoveSourcePathHandler : BaseHandler
{
    private FileMoveCommandArgumentsBuilder _fileMoveCommandArgumentsBuilder;

    public MoveSourcePathHandler(FileMoveCommandArgumentsBuilder fileMoveCommandArgumentsBuilder)
    {
        _fileMoveCommandArgumentsBuilder = fileMoveCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _fileMoveCommandArgumentsBuilder = _fileMoveCommandArgumentsBuilder.WithSourcePath(iterator.Current);

        if (!iterator.MoveNext())
        {
            return new HandleResult.Failed(new ArgumentNullError());
        }

        return Next is null
            ? new HandleResult.Failed(new ArgumentNullError())
            : Next.Handle(iterator);
    }
}