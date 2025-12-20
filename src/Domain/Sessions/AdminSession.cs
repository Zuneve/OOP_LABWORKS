namespace Itmo.ObjectOrientedProgramming.Domain.Sessions;

public class AdminSession
{
    public AdminSession(Guid sessionId)
    {
        SessionId = sessionId;
    }

    public Guid SessionId { get; }
}