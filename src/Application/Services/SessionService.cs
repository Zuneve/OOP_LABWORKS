using Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Operations;
using Itmo.ObjectOrientedProgramming.Application.Security;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Application.Services;

public class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;

    private readonly AdminPassword _adminPassword;

    public SessionService(IPersistenceContext context, AdminPassword adminPassword)
    {
        _context = context;
        _adminPassword = adminPassword;
    }

    public CreateUserSession.Response CreateUserSession(CreateUserSession.Request request)
    {
        Account? account = _context.AccountRepository.FindById(request.AccountId);

        if (account is null || account.AccountPinCode.Value != request.PinCode)
        {
            return new CreateUserSession.Response.Failed();
        }

        var userSession = new UserSession(
            Guid.NewGuid(),
            request.AccountId,
            new PinCode(request.PinCode));

        _context.UserSessionRepository.AddUserSession(userSession);

        return new CreateUserSession.Response.Success(userSession);
    }

    public CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request)
    {
        if (_adminPassword.IsEqual(request.InputPassword) is false)
        {
            return new CreateAdminSession.Response.Failed();
        }

        return new CreateAdminSession.Response.Success(new AdminSession(Guid.NewGuid()));
    }
}