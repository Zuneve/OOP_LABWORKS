namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileWriter : IWriter
{
    private readonly string _path;

    private readonly IFormatter _formatter;

    public FileWriter(IFormatter formatter, string path)
    {
        _formatter = formatter;
        _path = path;
    }

    public void WriteTittle(string tittle)
    {
        File.AppendAllText(_path, _formatter.FormatTittle(tittle));
    }

    public void WriteBody(string body)
    {
        File.AppendAllText(_path, _formatter.FormatBody(body));
    }

    public void Write(string tittle, string body)
    {
        File.AppendAllText(_path, _formatter.Format(tittle, body));
    }
}