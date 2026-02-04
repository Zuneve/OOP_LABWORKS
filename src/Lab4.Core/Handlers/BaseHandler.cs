using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers;

public abstract class BaseHandler : IHandler
{
    protected IHandler? Next { get; private set; }

    public IHandler AddNext(IHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }

        return handler;
    }

    public virtual HandleResult Handle(IEnumerator<string> iterator)
    {
        if (Next is null)
        {
            return new HandleResult.Failed(new WrongCommandError());
        }

        return Next.Handle(iterator);
    }
}