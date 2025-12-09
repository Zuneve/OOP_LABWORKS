using Itmo.ObjectOrientedProgramming.Lab4.Core;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public interface ICommandParser
{
    CommandOptions ParseInput(string input);
}