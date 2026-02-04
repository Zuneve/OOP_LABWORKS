using Application.Abstractions.Persistence.Repositories;

namespace Application.Abstractions.Persistence;

public interface IPersistenceContext
{
    IAccountRepository AccountRepository { get; }

    IOperationHistoryRepository OperationHistoryRepository { get; }

    ISessionRepository SessionRepository { get; }
}