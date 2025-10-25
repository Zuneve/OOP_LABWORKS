using Itmo.ObjectOrientedProgramming.Lab2.Formatters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class FormattingArchiver : IArchiver
{
    private readonly IFormatter _formatter;

    public FormattingArchiver(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void Save(Message message)
    {
        _formatter.WriteTittle(message.Tittle.Value);
        _formatter.WriteBody(message.Body.Value);
    }
}