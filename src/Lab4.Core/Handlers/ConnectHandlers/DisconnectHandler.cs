using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.ConnectHandlers;

public class DisconnectHandler : BaseHandler
{
    public override ICommand? Handle(CommandOptions commandOptions)
    {
        IList<string> parameters = commandOptions.Parameters;

        return parameters.Count > 1 || parameters[0] != "disconnect"
            ? Next?.Handle(commandOptions)
            : parameters.Count != 1 ? null : new DisconnectCommand();
    }
}