namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileWriter : IFormatter
{
    private readonly string _path;

    public FileWriter(string path)
    {
        _path = path;
    }

    public void WriteTittle(string tittle)
    {
        File.AppendAllText(_path, tittle + "\n");
    }

    public void WriteBody(string body)
    {
        File.AppendAllText(_path, body + "\n");
    }
}