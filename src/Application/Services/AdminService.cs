using Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Admin;
using Itmo.ObjectOrientedProgramming.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.Operations;
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
        var account = new Account(Guid.NewGuid(), new PinCode(request.PinCode));

        _context.AccountRepository.Add(account);

        _context.OperationHistoryRepository.AddOperation(
            new Operation(
                new Amount(0),
                account.Id,
                OperationType.CreateAccount,
                request.SessionId));

        return new CreateAccount.Response(account.MapToDto());
    }
}