using Itmo.ObjectOrientedProgramming.Lab2.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Message
{
    public MessageTittle Tittle { get; }

    public MessageBody Body { get; }

    public MessagePriorityScore PriorityScore { get; }

    public MessageReadStatus MessageStatus { get; }

    public MessageId Id { get; }

    public Message(MessageTittle messageTittle, MessageBody messageBody, MessagePriorityScore messagePriorityScore)
    {
        Tittle = messageTittle;
        Body = messageBody;
        PriorityScore = messagePriorityScore;
        MessageStatus = new MessageReadStatus(false);
        Id = new MessageId();
    }
}