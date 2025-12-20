using Itmo.ObjectOrientedProgramming.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Domain.Accounts;

public class Account
{
    public Account(AccountId id, PinCode accountPinCode)
    {
        Id = id;
        AccountBalance = new Balance(0);
        AccountPinCode = accountPinCode;
    }

    public AccountId Id { get; }

    public Balance AccountBalance { get; private set; }

    public PinCode AccountPinCode { get; }

    public DepositResult Deposit(decimal amount)
    {
        if (amount < 0)
        {
            return new DepositResult.Failed();
        }

        AccountBalance = new Balance(AccountBalance.Value + amount);

        return new DepositResult.Success(AccountBalance);
    }

    public WithdrawResult Withdraw(decimal amount)
    {
        if (amount < 0 || AccountBalance.Value < amount)
        {
            return new WithdrawResult.Failed();
        }

        AccountBalance = new Balance(AccountBalance.Value - amount);

        return new WithdrawResult.Success(AccountBalance);
    }
}