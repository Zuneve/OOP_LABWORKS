using Application.Abstractions.Persistence;
using Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        collection.AddSingleton<IAccountRepository, AccountRepository>();
        collection.AddSingleton<IOperationHistoryRepository, OperationHistoryRepository>();
        collection.AddSingleton<ISessionRepository, SessionRepository>();

        return collection;
    }
}