namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class ConsoleFormatter : MarkdownFormatter
{
    protected override void Write(string text)
    {
        Console.WriteLine(text);
    }
}