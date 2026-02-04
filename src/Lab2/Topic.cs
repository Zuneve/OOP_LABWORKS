using Itmo.ObjectOrientedProgramming.Lab2.Attributes;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Topic
{
    public TopicName Name { get; }

    private readonly IReadOnlyCollection<IRecipient> _recipients;

    public Topic(TopicName name, IReadOnlyCollection<IRecipient> recipients)
    {
        Name = name;
        _recipients = recipients;
    }

    public void Receive(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.Receive(message);
        }
    }
}