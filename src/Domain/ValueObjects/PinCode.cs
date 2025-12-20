namespace Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

public sealed record PinCode
{
    public PinCode(string value)
    {
        if (value.Length != 4 || value.All(char.IsDigit) is false)
        {
            throw new ArgumentException("PinCode must be a 4-length string of digits");
        }

        Value = value;
    }

    public string Value { get; }
}