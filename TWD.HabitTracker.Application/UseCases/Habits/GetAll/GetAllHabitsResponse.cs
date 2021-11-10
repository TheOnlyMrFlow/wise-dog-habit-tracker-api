using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Application.UseCases.Habits.GetAll;

public class GetAllHabitsResponse: IUseCaseResponse
{
    public GetAllHabitsResponse(IEnumerable<Habit> habits)
    {
        Habits = habits;
    }

    public IEnumerable<Habit> Habits { get; }
}