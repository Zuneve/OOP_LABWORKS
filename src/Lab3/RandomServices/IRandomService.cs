namespace Itmo.ObjectOrientedProgramming.Lab3.RandomServices;

public interface IRandomService
{
    int GetNext(int leftLimit, int rightLimit);
}