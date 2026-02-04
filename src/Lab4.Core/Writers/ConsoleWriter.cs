namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}