using Application.Abstractions.Persistence.Repositories.ResultTypes;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;

namespace Application.Abstractions.Persistence.Repositories;

public interface IAccountRepository
{
    void Add(Account account);

    Account? FindById(Guid accountId);

    UpdateAccountResult Update(Account account);
}