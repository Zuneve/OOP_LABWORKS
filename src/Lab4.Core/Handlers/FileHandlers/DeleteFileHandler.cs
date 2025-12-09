using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.FileHandlers;

public class DeleteFileHandler : BaseHandler
{
    public override ICommand? Handle(CommandOptions commandOptions)
    {
        IList<string> parameters = commandOptions.Parameters;

        return parameters.Count < 3 || !(parameters[0] == "file" && parameters[1] == "delete")
            ? Next?.Handle(commandOptions)
            : new DeleteFileCommand(parameters[2]);
    }
}