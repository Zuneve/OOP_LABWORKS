namespace Itmo.ObjectOrientedProgramming.Lab2.Loggers;

public class ConsoleLogger
{
    public void Log(Message message)
    {
        Console.WriteLine($"LOG {DateTime.Now:HH:mm:ss} : Title: {message.Tittle}, Body: {message.Body}");
    }
}