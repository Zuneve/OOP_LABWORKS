namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public abstract class MarkdownFormatter : IFormatter
{
    public void FormatTittle(Message message)
    {
        Write(FormatMarkdownTittle(message));
    }

    public void FormatBody(Message message)
    {
        Write(FormatMarkdownBody(message));
    }

    public void Format(Message message)
    {
        Write(FormatMarkdownTittle(message));
        Write(FormatMarkdownBody(message));
    }

    protected abstract void Write(string text);

    protected virtual string FormatMarkdownTittle(Message message)
    {
        return $"# {message.Tittle}";
    }

    protected virtual string FormatMarkdownBody(Message message)
    {
        return $"# {message.Body}";
    }
}