using Itmo.ObjectOrientedProgramming.Lab2.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class User
{
    public UserId Id { get; }

    private readonly Dictionary<MessageId, Message> _messages;

    public User()
    {
        Id = new UserId();
        _messages = new Dictionary<MessageId, Message>();
    }

    public void Receive(Message message)
    {
        _messages.TryAdd(message.Id, message);
    }

    public void MarkAsRead(MessageId messageId)
    {
        if (_messages[messageId].MessageStatus.IsRead)
        {
            throw new InvalidOperationException("Message is already marked as read.");
        }

        _messages[messageId].MessageStatus.MarkRead();
    }

    public bool HasMessage(MessageId messageId)
    {
        return _messages.ContainsKey(messageId);
    }

    public int MessageCount => _messages.Count;
}