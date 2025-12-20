using Application.Abstractions.Persistence.Queries;
using Application.Abstractions.Persistence.Repositories.ResultTypes;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;

namespace Application.Abstractions.Persistence.Repositories;

public interface IAccountRepository
{
    Account Add(Account account);

    IEnumerable<Account> Query(AccountQuery query);

    UpdateAccountResult Update(Account account);
}