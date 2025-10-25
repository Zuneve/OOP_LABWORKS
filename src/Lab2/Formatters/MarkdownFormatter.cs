namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkdownFormatter : IFormatter
{
    private readonly IFormatter _inner;

    public MarkdownFormatter(IFormatter inner)
    {
        _inner = inner;
    }

    public void WriteTittle(string tittle)
    {
        _inner.WriteTittle($"# {tittle}");
    }

    public void WriteBody(string body)
    {
        _inner.WriteTittle(body);
    }
}