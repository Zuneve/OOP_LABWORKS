using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Models;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Application.Mapping;

public static class AccountMappingExtensions
{
    public static AccountDto MapToDto(this Account account)
        => new AccountDto(account.Id.Value, account.AccountPinCode.Value);
}