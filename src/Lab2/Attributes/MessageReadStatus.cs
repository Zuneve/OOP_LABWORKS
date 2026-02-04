namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public record MessageReadStatus
{
    public bool IsRead { get; private set; }

    public MessageReadStatus(bool isRead)
    {
        IsRead = isRead;
    }

    public void MarkRead()
    {
        IsRead = true;
    }
}