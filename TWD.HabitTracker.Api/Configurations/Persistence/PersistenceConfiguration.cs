using Microsoft.EntityFrameworkCore;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Infra.Persistence.EFCore;
using TWD.HabitTracker.Infra.Persistence.EFCore.Habits;
using TWD.HabitTracker.Infra.Persistence.EFCore.InMemory;
using TWD.HabitTracker.Persistence.EFCore.SQLite;

namespace TWD.HabitTracker.Api.Configurations.Persistence;

public static class PersistenceConfiguration
{
    public static IServiceCollection ConfigureDatabaseSqlite(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<Context, SqliteContext>(_ => new SqliteContext(config["database:sqlite"]));
        return services;
    }
    
    public static IServiceCollection ConfigureDatabaseInMemory(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<Context, InMemoryContext>(_ => new InMemoryContext(config["database:inMemory"]));
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IHabitReadRepository, HabitRepository>();
        services.AddScoped<IHabitWriteRepository, HabitRepository>();
        
        return services;
    }
}