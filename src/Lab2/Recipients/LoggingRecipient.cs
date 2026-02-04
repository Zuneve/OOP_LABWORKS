using Itmo.ObjectOrientedProgramming.Lab2.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class LoggingRecipient
{
    private readonly IRecipient _recipient;

    private readonly ILogger _logger;

    public LoggingRecipient(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void Receive(Message message)
    {
        _logger.Log($"Tittle : {message.Tittle}, Body: {message.Body}");
        _recipient.Receive(message);
    }
}