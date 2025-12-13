using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.FileHandlers;

public class ShowFileHandler : BaseHandler
{
    public override ICommand? Handle(CommandOptions commandOptions)
    {
        IList<string> parameters = commandOptions.Parameters;

        IReadOnlyDictionary<string, string> flags = commandOptions.Flags;

        if (parameters.Count < 3 || parameters[0] != "file" || parameters[1] != "show")
        {
            return Next?.Handle(commandOptions);
        }

        flags.TryGetValue("-m", out string? mode);

        return mode switch
        {
            "console" => new ShowFileCommand(parameters[2], new ConsoleWriter()),
            _ => null,
        };
    }
}