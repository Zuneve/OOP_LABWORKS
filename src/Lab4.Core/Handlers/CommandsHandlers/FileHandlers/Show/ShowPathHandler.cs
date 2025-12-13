using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Show;

public class ShowPathHandler : BaseHandler
{
    private FileShowCommandArgumentsBuilder _fileShowCommandArgumentsBuilder;

    public ShowPathHandler(FileShowCommandArgumentsBuilder fileShowCommandArgumentsBuilder)
    {
        _fileShowCommandArgumentsBuilder = fileShowCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _fileShowCommandArgumentsBuilder = _fileShowCommandArgumentsBuilder.WithPath(iterator.Current);

        if (!iterator.MoveNext())
        {
            return new HandleResult.Failed(new WrongCommandError());
        }

        return Next is null
            ? new HandleResult.Failed(new WrongCommandError())
            : Next.Handle(iterator);
    }
}