using Microsoft.Extensions.Options;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using WD.HabitTracker.Infra.Persistence.Mongodb;
using WD.HabitTracker.Infra.Persistence.Mongodb.Repositories;

namespace TWD.HabitTracker.Api.Configurations.Persistence;

public static class PersistenceConfiguration
{
    // public static IServiceCollection ConfigureDatabaseSqlite(this IServiceCollection services, IConfiguration config)
    // {
    //     services.AddScoped<Context, SqliteContext>(_ => new SqliteContext(config["database:sqlite"]));
    //     return services;
    // }
    //
    // public static IServiceCollection ConfigureDatabaseInMemory(this IServiceCollection services, IConfiguration config)
    // {
    //     services.AddScoped<Context, InMemoryContext>(_ => new InMemoryContext(config["database:inMemory"]));
    //     return services;
    // }
    
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services
            .Configure<HabitTrackerMongoDatabaseSettings>(configuration.GetSection("MongoDatabaseSettings"))
            .AddSingleton(sp => sp.GetRequiredService<IOptions<HabitTrackerMongoDatabaseSettings>>().Value);
        
        services.AddScoped<IHabitReadRepository, HabitRepository>();
        services.AddScoped<IHabitWriteRepository, HabitRepository>();
        
        return services;
    }
}