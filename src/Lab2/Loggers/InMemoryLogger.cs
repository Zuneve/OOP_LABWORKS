namespace Itmo.ObjectOrientedProgramming.Lab2.Loggers;

public class InMemoryLogger : ILogger
{
    private readonly IReadOnlyList<string> _messages;

    public InMemoryLogger()
    {
        _messages = [];
    }

    public void Log(Message message)
    {
        _messages.Append($"LOG {DateTime.Now:HH:mm:ss} : Title: {message.Tittle}, Body: {message.Body}");
    }
}