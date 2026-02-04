using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.Admin;

public interface IAdminService
{
    CreateAccount.Response CreateAccount(CreateAccount.Request request);
}