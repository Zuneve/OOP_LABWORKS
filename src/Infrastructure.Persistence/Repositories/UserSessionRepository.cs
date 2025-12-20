using Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Infrastructure.Persistence.Repositories;

public class UserSessionRepository : IUserSessionRepository
{
    private readonly List<UserSession> _values = [];

    public void AddUserSession(UserSession userSession)
    {
        _values.Add(userSession);
    }

    public UserSession? TryGetUserSession(Guid sessionId)
    {
        return _values.FirstOrDefault(session => session.SessionId == sessionId);
    }
}