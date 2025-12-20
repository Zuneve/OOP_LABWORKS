using Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Admin;
using Itmo.ObjectOrientedProgramming.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.Operations;
using Itmo.ObjectOrientedProgramming.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Application.Services;

public class AdminService : IAdminService
{
    private readonly IPersistenceContext _context;

    public AdminService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        AdminSession? adminSession = _context.SessionRepository.TryGetAdminSession(request.SessionId);

        if (adminSession is null || request.SessionId != adminSession.SessionId)
        {
            return new CreateAccount.Response.Failed();
        }

        Account account = _context.AccountRepository.Add(
            new Account(AccountId.Default, new PinCode(request.PinCode)));

        _context.OperationHistoryRepository.AddOperation(
            new Operation(
                new Amount(account.AccountBalance.Value),
                OperationId.Default,
                new OperationType.CreateAccount(),
                account.Id));

        return new CreateAccount.Response.Success(account.MapToDto());
    }
}