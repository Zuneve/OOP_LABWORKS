namespace Itmo.ObjectOrientedProgramming.Domain.Operations;

public abstract record OperationType
{
    private OperationType() { }

    public sealed record CreateAccount() : OperationType;

    public sealed record ShowBalance() : OperationType;

    public sealed record Withdraw() : OperationType;

    public sealed record Deposit() : OperationType;
}