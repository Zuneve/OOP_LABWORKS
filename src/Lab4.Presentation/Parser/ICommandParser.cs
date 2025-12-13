namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public interface ICommandParser
{
    IEnumerable<string> ParseInput(string input);
}