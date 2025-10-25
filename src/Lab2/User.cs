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

    public bool TryMarkAsRead(Message message)
    {
        if (message.MessageStatus.IsRead)
        {
            return false;
        }

        message.MessageStatus.MarkRead();
        return true;
    }

    public bool HasMessage(Message message)
    {
        return _messages.Contains(message);
    }

    public int MessageCount => _messages.Count;
}