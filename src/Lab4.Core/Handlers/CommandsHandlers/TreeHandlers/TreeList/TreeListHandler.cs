using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.TreeHandlers.TreeList;

public class TreeListHandler : BaseHandler
{
    private IHandler? _subHandler;

    public void AddSubHandler(IHandler? subHandler)
    {
        _subHandler = subHandler;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        if (iterator.Current != "list")
        {
            return Next is null ?
                new HandleResult.Failed(new WrongCommandError())
                : Next.Handle(iterator);
        }

        if (!iterator.MoveNext())
            return new HandleResult.Failed(new WrongCommandError());

        return _subHandler is null
            ? new HandleResult.Failed(new WrongCommandError())
            : _subHandler.Handle(iterator);
    }
}