using Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Infrastructure.Persistence.Repositories;

public class OperationHistoryRepository : IOperationHistoryRepository
{
    private readonly List<Operation> _values = [];

    public Operation AddOperation(Operation operation)
    {
        var operationRepository = new Operation(
            operation.TransactionAmount,
            new OperationId(_values.Count),
            operation.Type,
            operation.AccountId);

        _values.Add(operationRepository);

        return operationRepository;
    }

    public IEnumerable<Operation> GetOperationsByAccountId(AccountId accountId)
    {
        return _values.Where(operation => operation.AccountId == accountId);
    }
}