using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.Operations;

namespace Application.Abstractions.Persistence.Repositories;

public interface IOperationHistoryRepository
{
    Operation AddOperation(Operation operation);

    IEnumerable<Operation> GetOperationsByAccountId(AccountId accountId);
}