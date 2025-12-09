using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

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

    public virtual ICommand? Handle(CommandOptions commandOptions)
    {
        return Next?.Handle(commandOptions);
    }
}