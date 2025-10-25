using Itmo.ObjectOrientedProgramming.Lab2.Formatters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class FormattingArchiver : IArchiver
{
    private readonly List<string> _messages;

    private readonly IFormatter _formatter;

    public FormattingArchiver(IFormatter formatter)
    {
        _messages = [];
        _formatter = formatter;
    }

    public void Save(Message message)
    {
        _messages.Add(_formatter.Format(message.Tittle.Value, message.Body.Value));
    }
}