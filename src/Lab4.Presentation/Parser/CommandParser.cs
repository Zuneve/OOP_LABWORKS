namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class CommandParser : ICommandParser
{
    public IEnumerable<string> ParseInput(string input)
    {
        return input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    }
}