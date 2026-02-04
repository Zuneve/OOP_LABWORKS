using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Show;

public class ShowConsoleHandler : BaseHandler
{
    private FileShowCommandArgumentsBuilder _fileShowCommandArgumentsBuilder;

    public ShowConsoleHandler(FileShowCommandArgumentsBuilder fileShowCommandArgumentsBuilder)
    {
        _fileShowCommandArgumentsBuilder = fileShowCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        if (iterator.Current != "console")
        {
            return Next is null
                ? new HandleResult.Failed(new WrongCommandError())
                : Next.Handle(iterator);
        }

        _fileShowCommandArgumentsBuilder = _fileShowCommandArgumentsBuilder.WithWriter(new ConsoleWriter());

        return new HandleResult.Success(_fileShowCommandArgumentsBuilder);
    }
}