using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Domain.ResultTypes;

public abstract record DepositResult
{
    private DepositResult() { }

    public sealed record Success(Balance NewBalance) : DepositResult;

    public sealed record Failed() : DepositResult;
}