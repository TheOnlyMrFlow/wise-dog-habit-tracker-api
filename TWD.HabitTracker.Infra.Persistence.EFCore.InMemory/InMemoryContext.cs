using Microsoft.EntityFrameworkCore;

namespace TWD.HabitTracker.Infra.Persistence.EFCore.InMemory;

public class InMemoryContext : Context
{
    private readonly string _databaseName;

    private const string DefaultDbName = "InMemoryDatabase";
    
    public InMemoryContext(string? databaseName)
        => _databaseName = databaseName ?? DefaultDbName;

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(InMemoryContext).Assembly);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseInMemoryDatabase(_databaseName);
}