using Itmo.ObjectOrientedProgramming.Domain.Operations;

namespace Application.Abstractions.Persistence.Repositories;

public interface IOperationHistoryRepository
{
    void AddOperation(Operation operation);

    IEnumerable<Operation> GetOperationsByAccountId(Guid accountId);
}