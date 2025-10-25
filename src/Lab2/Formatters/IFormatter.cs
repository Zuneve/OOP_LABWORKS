namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public interface IFormatter
{
    string FormatTittle(string tittle);

    string FormatBody(string body);

    string Format(string tittle, string body);
}