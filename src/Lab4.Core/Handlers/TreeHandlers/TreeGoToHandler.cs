using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.TreeHandlers;

public class TreeGoToHandler : BaseHandler
{
    public override ICommand? Handle(CommandOptions commandOptions)
    {
        IList<string> parameters = commandOptions.Parameters;

        return parameters.Count < 3 || !(parameters[0] == "tree" && parameters[1] == "goto")
            ? Next?.Handle(commandOptions)
            : new TreeGoToCommand(parameters[2]);
    }
}