using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Domain.Operations;

public class Operation
{
    public Operation(Amount amount, OperationId id, OperationType type, AccountId accountId)
    {
        TransactionAmount = amount;
        Id = id;
        Type = type;
        AccountId = accountId;
        TransactionTime = DateTime.Now;
    }

    public OperationId Id { get; }

    public AccountId AccountId { get; }

    public Amount TransactionAmount { get; }

    public OperationType Type { get; }

    public DateTime TransactionTime { get; }
}