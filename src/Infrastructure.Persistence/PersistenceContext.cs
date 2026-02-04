using Application.Abstractions.Persistence;
using Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Infrastructure.Persistence;

public sealed class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(IAccountRepository accountRepository, IOperationHistoryRepository operationHistoryRepository, ISessionRepository sessionRepository)
    {
        AccountRepository = accountRepository;
        OperationHistoryRepository = operationHistoryRepository;
        SessionRepository = sessionRepository;
    }

    public IAccountRepository AccountRepository { get; }

    public IOperationHistoryRepository OperationHistoryRepository { get; }

    public ISessionRepository SessionRepository { get; }
}