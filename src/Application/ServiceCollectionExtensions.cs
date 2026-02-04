using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Admin;
using Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IOperationHistoryService, OperationHistoryService>();
        collection.AddScoped<ISessionService, SessionService>();
        collection.AddScoped<IAdminService, AdminService>();
        return collection;
    }
}