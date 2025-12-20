using Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    UserSession CreateUserSession(AccountId accountId, PinCode pinCode);

    AdminSession CreateAdminSession();

    IEnumerable<BaseSession> Query(SessionQuery query);
}