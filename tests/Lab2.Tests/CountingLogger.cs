using Itmo.ObjectOrientedProgramming.Lab2.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class CountingLogger : ILogger
{
    public int CountLogs { get; private set; }

    public CountingLogger()
    {
        CountLogs = 0;
    }

    public void Log(string message)
    {
        CountLogs++;
    }
}