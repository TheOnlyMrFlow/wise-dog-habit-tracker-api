using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Application.Infra.Persistence.Habits;

public interface IHabitReadRepository
{
    IEnumerable<Habit> GetAll(Guid userId);
    Task<Habit?> GetAsync(Guid habitId);
}