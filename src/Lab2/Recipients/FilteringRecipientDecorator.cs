using Itmo.ObjectOrientedProgramming.Lab2.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class FilteringRecipientDecorator : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly MinAllowedImportance _minAllowedImportance;

    public FilteringRecipientDecorator(IRecipient recipient, MinAllowedImportance minAllowedImportance)
    {
        _recipient = recipient;
        _minAllowedImportance = minAllowedImportance;
    }

    public void Receive(Message message)
    {
        if (message.PriorityScore.Value < _minAllowedImportance.Value)
        {
            return;
        }

        _recipient.Receive(message);
    }
}