using Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory;
using Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory.Operations;
using Itmo.ObjectOrientedProgramming.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Application.Services;

public class OperationHistoryService : IOperationHistoryService
{
    private readonly IPersistenceContext _context;

    public OperationHistoryService(IPersistenceContext context)
    {
        _context = context;
    }

    public ShowOperationHistory.Response ShowOperationHistory(ShowOperationHistory.Request request)
    {
        UserSession? userSession = _context.SessionRepository.TryGetUserSession(request.SessionId);

        if (userSession is null)
        {
            return new ShowOperationHistory.Response.Failed();
        }

        Account? account = _context.AccountRepository.FindById(userSession.AccountId);

        if (account is null)
        {
            return new ShowOperationHistory.Response.Failed();
        }

        return new ShowOperationHistory.Response.Success(
            _context.OperationHistoryRepository.GetOperationsByAccountId(account.Id)
                .Select(operation => operation.MapToDto())
                .ToList());
    }
}