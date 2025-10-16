namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public record TopicName
{
    public string Value { get; }

    public TopicName(string name)
    {
        Value = name;
    }
}