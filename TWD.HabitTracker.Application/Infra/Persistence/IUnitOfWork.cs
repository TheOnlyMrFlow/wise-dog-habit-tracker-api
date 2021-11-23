namespace TWD.HabitTracker.Application.Infra.Persistence;

public interface IUnitOfWork
{
    Task<int> SaveAsync();
}