using TWD.HabitTracker.Application.Infra.Persistence;

namespace TWD.HabitTracker.Infra.Persistence.EFCore;

public sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly Context _context;
    private bool _disposed;

    public UnitOfWork(Context context)
    {
        _context = context;
    }

    public async Task<int> SaveAsync()
    {
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows;
    }
    
    /// <inheritdoc />
    public void Dispose() => Dispose(true);

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing) _context.Dispose();

        _disposed = true;
    }
}