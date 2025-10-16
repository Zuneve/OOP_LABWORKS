namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public record MessageId
{
    public Guid Value { get; }

    public MessageId()
    {
        Value = Guid.NewGuid();
    }
}