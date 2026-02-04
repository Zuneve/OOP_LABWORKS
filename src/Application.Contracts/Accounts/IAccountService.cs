using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts;

public interface IAccountService
{
    ShowBalanceAccount.Response ShowBalanceAccount(ShowBalanceAccount.Request request);

    Deposit.Response Deposit(Deposit.Request request);

    Withdraw.Response Withdraw(Withdraw.Request request);
}