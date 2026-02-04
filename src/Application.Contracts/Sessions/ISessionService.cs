using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Operations;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions;

public interface ISessionService
{
    CreateUserSession.Response CreateUserSession(CreateUserSession.Request request);

    CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request);
}