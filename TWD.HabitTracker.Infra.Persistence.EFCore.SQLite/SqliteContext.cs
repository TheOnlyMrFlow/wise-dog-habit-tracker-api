using Microsoft.EntityFrameworkCore;
using TWD.HabitTracker.Infra.Persistence.EFCore;

namespace TWD.HabitTracker.Persistence.EFCore.SQLite;

public class SqliteContext : Context
{
    private readonly string _connectionString;
    
    public SqliteContext(string connectionString) 
        => _connectionString = connectionString;

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqliteContext).Assembly);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseSqlite(_connectionString);
}