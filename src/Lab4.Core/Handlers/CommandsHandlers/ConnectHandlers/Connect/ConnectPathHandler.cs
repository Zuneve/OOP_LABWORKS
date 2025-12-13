using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.ConnectCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.ConnectHandlers.Connect;

public class ConnectPathHandler : BaseHandler
{
    private ConnectCommandArgumentsBuilder _connectCommandArgumentsBuilder;

    public ConnectPathHandler(ConnectCommandArgumentsBuilder connectCommandArgumentsBuilder)
    {
        _connectCommandArgumentsBuilder = connectCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _connectCommandArgumentsBuilder = _connectCommandArgumentsBuilder.WithPath(iterator.Current);

        if (!iterator.MoveNext())
        {
            return new HandleResult.Failed(new WrongCommandError());
        }

        return Next is null
            ? new HandleResult.Failed(new WrongCommandError())
            : Next.Handle(iterator);
    }
}