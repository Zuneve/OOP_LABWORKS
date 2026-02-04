using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.ConnectCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.ConnectHandlers.Connect;

public class ConnectLocalSystemHandler : BaseHandler
{
    private ConnectCommandArgumentsBuilder _connectCommandArgumentsBuilder;

    public ConnectLocalSystemHandler(ConnectCommandArgumentsBuilder connectCommandArgumentsBuilder)
    {
        _connectCommandArgumentsBuilder = connectCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        if (iterator.Current != "local")
        {
            return Next is null
                ? new HandleResult.Failed(new WrongCommandError())
                : Next.Handle(iterator);
        }

        _connectCommandArgumentsBuilder = _connectCommandArgumentsBuilder.WithFileSystem(new LocalFileSystem());

        return new HandleResult.Success(_connectCommandArgumentsBuilder);
    }
}