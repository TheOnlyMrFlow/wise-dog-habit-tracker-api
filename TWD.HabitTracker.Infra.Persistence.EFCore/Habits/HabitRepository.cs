using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Infra.Persistence.EFCore.Habits;

public class HabitRepository : IHabitReadRepository, IHabitWriteRepository
{
    private readonly Context _context;

    public HabitRepository(Context context)
    {
        _context = context;
    }

    public IEnumerable<Habit> GetAll() => _context.Habits;

    public async Task AddAsync(Habit habit) => await _context.Habits.AddAsync(habit);
}