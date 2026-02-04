using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Domain.ResultTypes;

public abstract record WithdrawResult
{
    private WithdrawResult() { }

    public sealed record Success(Balance NewBalance) : WithdrawResult;

    public sealed record Failed() : WithdrawResult;
}