namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileFormatter : MarkdownFormatter
{
    private readonly string _path;

    public FileFormatter(string path)
    {
        _path = path;
    }

    protected override void Write(string text)
    {
        File.AppendAllText(_path, text + Environment.NewLine);
    }
}