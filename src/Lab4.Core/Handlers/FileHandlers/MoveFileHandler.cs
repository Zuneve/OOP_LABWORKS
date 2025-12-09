using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.FileHandlers;

public class MoveFileHandler : BaseHandler
{
    public override ICommand? Handle(CommandOptions commandOptions)
    {
        IList<string> parameters = commandOptions.Parameters;

        return parameters.Count < 4 || !(parameters[0] == "file" && parameters[1] == "move")
            ? Next?.Handle(commandOptions)
            : new MoveFileCommand(parameters[2], parameters[3]);
    }
}