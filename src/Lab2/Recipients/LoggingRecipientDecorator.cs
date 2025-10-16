using Itmo.ObjectOrientedProgramming.Lab2.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class LoggingRecipientDecorator
{
    private readonly IRecipient _recipient;

    private readonly ILogger _logger;

    public LoggingRecipientDecorator(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void Receive(Message message)
    {
        _logger.Log(message);
        _recipient.Receive(message);
    }
}