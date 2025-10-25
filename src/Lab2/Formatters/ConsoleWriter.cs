namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class ConsoleWriter : IWriter
{
    private readonly IFormatter _formatter;

    public ConsoleWriter(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void WriteTittle(string tittle)
    {
        Console.WriteLine(_formatter.FormatTittle(tittle));
    }

    public void WriteBody(string body)
    {
        Console.WriteLine(_formatter.FormatBody(body));
    }

    public void Write(string tittle, string body)
    {
        Console.WriteLine(_formatter.Format(tittle, body));
    }
}