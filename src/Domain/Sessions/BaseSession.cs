namespace Itmo.ObjectOrientedProgramming.Domain.Sessions;

public abstract class BaseSession
{
    protected BaseSession(Guid sessionId)
    {
        SessionId = sessionId;
    }

    public Guid SessionId { get; }
}