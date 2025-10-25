namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkdownFormatter : IFormatter
{
    public string FormatTittle(string tittle)
    {
        return $"# {tittle}";
    }

    public string FormatBody(string body)
    {
        return $"{body}";
    }

    public string Format(string tittle, string body)
    {
        return $"Tittle: {FormatTittle(tittle)}\nBody: {FormatBody(body)}";
    }
}