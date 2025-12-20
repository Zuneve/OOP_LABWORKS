using Application.Abstractions.Persistence.Repositories.ResultTypes;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;

namespace Application.Abstractions.Persistence.Repositories;

public interface IAccountRepository
{
    Account Add(Account account);

    Account? FindById(AccountId accountId);

    UpdateAccountResult Update(Account account);
}