namespace Itmo.ObjectOrientedProgramming.Lab2.Loggers;

public class InMemoryLogger : ILogger
{
    private readonly List<string> _messages;

    public InMemoryLogger()
    {
        _messages = [];
    }

    public void Log(string message)
    {
        _messages.Add($"LOG {DateTime.Now:HH:mm:ss} : Message: {message}");
    }
}