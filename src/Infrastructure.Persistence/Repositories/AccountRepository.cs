using Application.Abstractions.Persistence.Queries;
using Application.Abstractions.Persistence.Repositories;
using Application.Abstractions.Persistence.Repositories.ResultTypes;
using Itmo.ObjectOrientedProgramming.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Infrastructure.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly List<Account> _values = [];

    public Account Add(Account account)
    {
        var accountRepository = new Account(new AccountId(_values.Count), account.AccountPinCode);
        _values.Add(accountRepository);

        return accountRepository;
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        return _values.
            Where(account => query.Ids is [] || query.Ids.Contains(account.Id));
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