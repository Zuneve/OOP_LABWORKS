using Application.Abstractions.Persistence;
using Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Infrastructure.Persistence;

public sealed class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(IAccountRepository accountRepository, IOperationHistoryRepository operationHistoryRepository, IUserSessionRepository userSessionRepository)
    {
        AccountRepository = accountRepository;
        OperationHistoryRepository = operationHistoryRepository;
        UserSessionRepository = userSessionRepository;
    }

    public IAccountRepository AccountRepository { get; }

    public IOperationHistoryRepository OperationHistoryRepository { get; }

    public IUserSessionRepository UserSessionRepository { get; }
}