using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.ConnectHandlers;

public class ConnectHandler : BaseHandler
{
    public override ICommand? Handle(CommandOptions commandOptions)
    {
        IList<string> parameters = commandOptions.Parameters;

        IReadOnlyDictionary<string, string> flags = commandOptions.Flags;

        if (parameters.Count < 2 || parameters[0] != "connect")
        {
            return Next?.Handle(commandOptions);
        }

        string mode = flags.GetValueOrDefault("-m", "local");

        return mode switch
        {
            "local" => new ConnectCommand(parameters[1]),
            _ => null,
        };
    }
}