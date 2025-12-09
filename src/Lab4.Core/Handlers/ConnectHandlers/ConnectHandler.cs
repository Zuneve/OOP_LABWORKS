using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.ConnectHandlers;

public class ConnectHandler : BaseHandler
{
    private readonly IFileSystem _fileSystem;

    public ConnectHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

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
            "local" => new ConnectCommand(parameters[1], _fileSystem),
            _ => null,
        };
    }
}