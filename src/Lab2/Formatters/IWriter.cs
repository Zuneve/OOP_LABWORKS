namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public interface IWriter
{
    void WriteTittle(string tittle);

    void WriteBody(string body);

    void Write(string tittle, string body);
}