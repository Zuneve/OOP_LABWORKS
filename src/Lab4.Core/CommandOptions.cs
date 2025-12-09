namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public class CommandOptions
{
    public IList<string> Parameters { get; }

    public IReadOnlyDictionary<string, string> Flags { get; }

    public CommandOptions(
        IEnumerable<string> parameters,
        IDictionary<string, string> flags)
    {
        Parameters = parameters.ToList();
        Flags = new Dictionary<string, string>(flags);
    }
}