using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        var parser = new CommandParser();
        var mainHandler = new MainHandler(new ConsoleWriter(), new TreeViewSymbolsSettings());
        var connectionContext = new ConnectionContext();
        var system = new LocalFileSystem(connectionContext);
        connectionContext.SetFileSystem(system);

        while (true)
        {
            string? line = Console.ReadLine();

            if (line is null or "")
            {
                break;
            }

            CommandOptions commandOptions = parser.ParseInput(line);

            ICommand? command = mainHandler.Handle(commandOptions);

            command?.Execute(connectionContext);
        }
    }
}