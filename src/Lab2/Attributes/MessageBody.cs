namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public record MessageBody
{
    public string Value { get; }

    public MessageBody(string body)
    {
        Value = body;
    }
}