namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public record MessageTittle
{
    public string Value { get; }

    public MessageTittle(string header)
    {
        Value = header;
    }
}