using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Domain.Sessions;

public class UserSession : BaseSession
{
    public UserSession(Guid sessionId, AccountId accountId, PinCode userPinCode)
        : base(sessionId)
    {
        AccountId = accountId;
        UserPinCode = userPinCode;
    }

    public AccountId AccountId { get; }

    public PinCode UserPinCode { get; }
}