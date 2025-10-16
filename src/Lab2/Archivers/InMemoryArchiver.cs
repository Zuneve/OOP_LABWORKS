namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class InMemoryArchiver : IArchiver
{
    private readonly IReadOnlyList<Message> _messages;

    public InMemoryArchiver(IReadOnlyList<Message> messages)
    {
        _messages = messages;
    }

    public void Save(Message message)
    {
        _messages.Append(message);
    }
}