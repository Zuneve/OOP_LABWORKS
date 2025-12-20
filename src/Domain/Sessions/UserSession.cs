using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Domain.Sessions;

public class UserSession
{
    public UserSession(Guid sessionId, Guid accountId, PinCode userPinCode)
    {
        SessionId = sessionId;
        AccountId = accountId;
        UserPinCode = userPinCode;
    }

    public Guid SessionId { get; }

    public Guid AccountId { get; }

    public PinCode UserPinCode { get; }
}