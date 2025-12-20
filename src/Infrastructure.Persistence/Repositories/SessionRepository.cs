using Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly List<BaseSession> _values = [];

    public UserSession CreateUserSession(AccountId accountId, PinCode pinCode)
    {
        var userSession = new UserSession(Guid.NewGuid(), accountId, pinCode);

        _values.Add(userSession);

        return userSession;
    }

    public AdminSession CreateAdminSession()
    {
        var adminSession = new AdminSession(Guid.NewGuid());

        _values.Add(adminSession);

        return adminSession;
    }

    public UserSession? TryGetUserSession(Guid sessionId)
    {
        return _values
            .OfType<UserSession>()
            .FirstOrDefault(session => session.SessionId == sessionId);
    }

    public AdminSession? TryGetAdminSession(Guid sessionId)
    {
        return _values
            .OfType<AdminSession>()
            .FirstOrDefault(session => session.SessionId == sessionId);
    }
}