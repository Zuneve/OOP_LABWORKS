using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        var treeViewSymbolsSettings = new TreeViewSymbolsSettings();
        var writer = new ConsoleWriter();
        var parser = new CommandParser();
        var mainHandler = new MainHandler(writer, treeViewSymbolsSettings);
        var connectionContext = new ConnectionContext();

        while (true)
        {
            string? line = Console.ReadLine();

            if (line is null or "")
            {
                break;
            }

            IEnumerator<string> iterator = parser.ParseInput(line).GetEnumerator();

            iterator.MoveNext();

            HandleResult handleResult = mainHandler.Handle(iterator);

            if (handleResult is not HandleResult.Success success
                || success.Builder.Build() is not CommandArgumentsBuilderResult.Success successBuildResult
                || successBuildResult.Command.Execute(connectionContext) is not CommandExecuteResult.Success)
            {
                writer.Write("Something wrong");
            }
        }
    }
}