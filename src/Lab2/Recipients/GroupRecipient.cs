namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _recipients;

    public GroupRecipient()
    {
        _recipients = [];
    }

    public void Receive(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.Receive(message);
        }
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void DeleteRecipient(IRecipient recipient)
    {
        _recipients.Remove(recipient);
    }
}