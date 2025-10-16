namespace Itmo.ObjectOrientedProgramming.Lab2;

public class User
{
    private readonly List<Message> _messages;

    public User()
    {
        _messages = [];
    }

    public void Receive(Message message)
    {
        _messages.Add(message);
    }

    public void MarkAsRead(Message message)
    {
        if (message.MessageStatus.IsRead)
        {
            throw new InvalidOperationException("Message is already marked as read.");
        }

        message.MessageStatus.MarkRead();
    }

    public bool HasMessage(Message message)
    {
        return _messages.Contains(message);
    }

    public int MessageCount => _messages.Count;
}