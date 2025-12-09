using Itmo.ObjectOrientedProgramming.Lab4.Core;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class CommandParser : ICommandParser
{
    public CommandOptions ParseInput(string input)
    {
        List<string> listArguments = input.
            Split(" ", StringSplitOptions.RemoveEmptyEntries).
            ToList();

        var parameters = new List<string>();

        var flags = new Dictionary<string, string>();

        bool isPreviousArgumentFlag = false;
        string currentFlag = string.Empty;

        foreach (string argument in listArguments)
        {
            if (isPreviousArgumentFlag)
            {
                isPreviousArgumentFlag = false;
                flags.Add(currentFlag, argument);
                continue;
            }

            if (argument.StartsWith('-'))
            {
                isPreviousArgumentFlag = true;
                currentFlag = argument;
            }
            else
            {
                parameters.Add(argument);
            }
        }

        return new CommandOptions(parameters, flags);
    }
}