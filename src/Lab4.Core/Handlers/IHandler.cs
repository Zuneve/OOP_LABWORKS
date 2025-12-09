using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers;

public interface IHandler
{
    IHandler AddNext(IHandler handler);

    ICommand? Handle(CommandOptions commandOptions);
}