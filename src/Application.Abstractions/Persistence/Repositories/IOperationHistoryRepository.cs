using Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Domain.Operations;

namespace Application.Abstractions.Persistence.Repositories;

public interface IOperationHistoryRepository
{
    Operation AddOperation(Operation operation);

    IEnumerable<Operation> Query(OperationHistoryQuery query);
}