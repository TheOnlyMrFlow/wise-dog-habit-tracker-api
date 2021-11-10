using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Application.Infra.Persistence.Habits;

public interface IHabitWriteRepository
{
    Task AddAsync(Habit habit);
}