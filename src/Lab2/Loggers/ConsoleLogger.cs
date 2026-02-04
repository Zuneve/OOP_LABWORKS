namespace Itmo.ObjectOrientedProgramming.Lab2.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"LOG {DateTime.Now:HH:mm:ss} : Message: {message}");
    }
}