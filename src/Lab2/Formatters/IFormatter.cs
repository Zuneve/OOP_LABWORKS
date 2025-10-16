namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public interface IFormatter
{
    void FormatTittle(Message message);

    void FormatBody(Message message);

    void Format(Message message);
}