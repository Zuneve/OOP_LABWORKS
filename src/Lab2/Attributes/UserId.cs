namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public record UserId
{
    public Guid Value { get; }

    public UserId()
    {
        Value = Guid.NewGuid();
    }
}