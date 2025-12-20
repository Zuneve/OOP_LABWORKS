using Itmo.ObjectOrientedProgramming.Domain.Sessions;

namespace Application.Abstractions.Persistence.Repositories;

public interface IUserSessionRepository
{
    void AddUserSession(UserSession userSession);

    UserSession? TryGetUserSession(Guid sessionId);
}