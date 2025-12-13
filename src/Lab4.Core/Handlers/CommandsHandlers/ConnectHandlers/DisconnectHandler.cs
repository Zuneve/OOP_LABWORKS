using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.ConnectCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.ConnectHandlers;

public class DisconnectHandler : BaseHandler
{
    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        if (iterator.Current != "disconnect")
        {
            return Next is null ?
                new HandleResult.Failed(new WrongCommandError())
                : Next.Handle(iterator);
        }

        return new HandleResult.Success(new DisconnectCommandArgumentsBuilder());
    }
}