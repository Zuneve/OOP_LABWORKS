using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Domain.Operations;

public class Operation
{
    public Operation(Amount amount, Guid id, OperationType type, Guid accountId)
    {
        TransactionAmount = amount;
        Id = id;
        Type = type;
        AccountId = accountId;
        TransactionTime = DateTime.Now;
    }

    public Guid Id { get; }

    public Guid AccountId { get; }

    public Amount TransactionAmount { get; }

    public OperationType Type { get; }

    public DateTime TransactionTime { get; }
}