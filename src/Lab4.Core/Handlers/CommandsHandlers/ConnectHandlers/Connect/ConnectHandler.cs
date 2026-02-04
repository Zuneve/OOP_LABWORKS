using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.ConnectHandlers.Connect;

public class ConnectHandler : BaseHandler
{
    private IHandler? _subHandler;

    public void AddSubHandler(IHandler? subHandler)
    {
        _subHandler = subHandler;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        if (iterator.Current != "connect")
        {
            return Next is null
                ? new HandleResult.Failed(new WrongCommandError())
                : Next.Handle(iterator);
        }

        if (!iterator.MoveNext())
        {
            return new HandleResult.Failed(new WrongCommandError());
        }

        return _subHandler is null
            ? new HandleResult.Failed(new WrongCommandError())
            : _subHandler.Handle(iterator);
    }
}