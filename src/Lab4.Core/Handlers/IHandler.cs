using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers;

public interface IHandler
{
    IHandler AddNext(IHandler handler);

    HandleResult Handle(IEnumerator<string> iterator);
}