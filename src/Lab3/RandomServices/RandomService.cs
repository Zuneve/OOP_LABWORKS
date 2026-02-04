using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.RandomServices;

public class RandomService : IRandomService
{
    public int GetNext(int leftLimit, int rightLimit)
    {
        return RandomNumberGenerator.GetInt32(leftLimit, rightLimit);
    }
}