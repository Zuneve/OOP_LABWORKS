using Application.Abstractions.Persistence.Repositories;
using Application.Abstractions.Persistence.Repositories.ResultTypes;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Infrastructure.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly List<Account> _values = [];

    public void Add(Account account)
    {
        _values.Add(account);
    }

    public Account? FindById(Guid accountId)
    {
        return _values.FirstOrDefault(account => account.Id == accountId);
    }

    public UpdateAccountResult Update(Account account)
    {
        for (int i = 0; i < _values.Count; i++)
        {
            if (_values[i].Id == account.Id)
            {
                _values[i] = account;
                return new UpdateAccountResult.Success();
            }
        }

        return new UpdateAccountResult.Failed();
    }
}