using Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Infrastructure.Persistence.Repositories;

public class OperationHistoryRepository : IOperationHistoryRepository
{
    private readonly List<Operation> _values = [];

    public void AddOperation(Operation operation)
    {
        _values.Add(operation);
    }

    public IEnumerable<Operation> GetOperationsByAccountId(Guid accountId)
    {
        return _values.Where(operation => operation.AccountId == accountId);
    }
}