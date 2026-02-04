namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class ConsoleWriter : IFormatter
{
    public void WriteTittle(string tittle)
    {
        Console.WriteLine(tittle);
    }

    public void WriteBody(string body)
    {
        Console.WriteLine(body);
    }
}