using Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Lab5Tests
{
    private readonly IAccountRepository _accountRepository = Substitute.For<IAccountRepository>();

    [Fact]
    public void WithdrawResult_ShouldReturn_Success_When_Account_Has_Enough_Money()
    {
        // arrange
        var account = new Account(AccountId.Default, new PinCode("1234"));
        _accountRepository.FindById(account.Id).Returns(account);

        // act
        account.Deposit(1000);
        WithdrawResult result = account.Withdraw(666);
        _accountRepository.Update(account);

        // assert
        Assert.IsType<WithdrawResult.Success>(result);
        Assert.Equal(334, account.AccountBalance.Value);
        _accountRepository.Received();
    }

    [Fact]
    public void WithdrawResult_ShouldReturn_Failed_When_Account_HasNot_Enough_Money()
    {
        // arrange
        var account = new Account(AccountId.Default, new PinCode("1234"));
        _accountRepository.FindById(account.Id).Returns(account);

        // act
        account.Deposit(1000);
        WithdrawResult result = account.Withdraw(1703);
        _accountRepository.Update(account);

        // assert
        Assert.IsType<WithdrawResult.Failed>(result);
        _accountRepository.DidNotReceive();
    }

    [Fact]
    public void Account_Should_Update_Balance_After_Deposit()
    {
        // arrange
        var account = new Account(AccountId.Default, new PinCode("1234"));
        _accountRepository.FindById(account.Id).Returns(account);

        // act
        account.Deposit(1000);
        _accountRepository.Update(account);
        account.Deposit(2000);
        _accountRepository.Update(account);
        account.Deposit(3000);
        _accountRepository.Update(account);

        // assert
        Assert.Equal(6000, account.AccountBalance.Value);
        _accountRepository.Received(3).Update(account);
    }
}