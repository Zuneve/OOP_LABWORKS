namespace Itmo.ObjectOrientedProgramming.Lab2.Loggers;

public class InMemoryLogger : ILogger
{
    private readonly List<string> _messages;

    public InMemoryLogger()
    {
        _messages = [];
    }

    public void Log(Message message)
    {
        _messages.Add($"LOG {DateTime.Now:HH:mm:ss} : Title: {message.Tittle}, Body: {message.Body}");
    }
}