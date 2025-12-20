using Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.Operations;
using Itmo.ObjectOrientedProgramming.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Application.Services;

public class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public ShowBalanceAccount.Response ShowBalanceAccount(ShowBalanceAccount.Request request)
    {
        UserSession? userSession = _context.SessionRepository.TryGetUserSession(request.SessionId);

        if (userSession is null)
        {
            return new ShowBalanceAccount.Response.Failed();
        }

        Account? account = _context.AccountRepository.FindById(userSession.AccountId);

        if (account is null)
        {
            return new ShowBalanceAccount.Response.Failed();
        }

        _context.OperationHistoryRepository.AddOperation(
            new Operation(
                new Amount(account.AccountBalance.Value),
                OperationId.Default,
                new OperationType.ShowBalance(),
                account.Id));

        return new ShowBalanceAccount.Response.Success(account.AccountBalance.Value);
    }

    public Deposit.Response Deposit(Deposit.Request request)
    {
        UserSession? userSession = _context.SessionRepository.TryGetUserSession(request.SessionId);

        if (userSession is null)
        {
            return new Deposit.Response.Failed();
        }

        Account? account = _context.AccountRepository.FindById(userSession.AccountId);

        if (account is null)
        {
            return new Deposit.Response.Failed();
        }

        DepositResult result = account.Deposit(request.Amount);

        if (result is DepositResult.Failed)
        {
            return new Deposit.Response.Failed();
        }

        _context.OperationHistoryRepository.AddOperation(
            new Operation(
                new Amount(account.AccountBalance.Value),
                OperationId.Default,
                new OperationType.Deposit(),
                account.Id));

        return new Deposit.Response.Success(account.AccountBalance.Value);
    }

    public Withdraw.Response Withdraw(Withdraw.Request request)
    {
        UserSession? userSession = _context.SessionRepository.TryGetUserSession(request.SessionId);

        if (userSession is null)
        {
            return new Withdraw.Response.Failed();
        }

        Account? account = _context.AccountRepository.FindById(userSession.AccountId);

        if (account is null)
        {
            return new Withdraw.Response.Failed();
        }

        WithdrawResult result = account.Withdraw(request.Amount);

        if (result is WithdrawResult.Failed)
        {
            return new Withdraw.Response.Failed();
        }

        _context.OperationHistoryRepository.AddOperation(
            new Operation(
                new Amount(account.AccountBalance.Value),
                OperationId.Default,
                new OperationType.Withdraw(),
                account.Id));

        return new Withdraw.Response.Success(account.AccountBalance.Value);
    }
}