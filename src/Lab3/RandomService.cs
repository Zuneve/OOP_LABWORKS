using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class RandomService
{
    public int GetNext(int leftLimit, int rightLimit)
    {
        return RandomNumberGenerator.GetInt32(leftLimit, rightLimit);
    }
}