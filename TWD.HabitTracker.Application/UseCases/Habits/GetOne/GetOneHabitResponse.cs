using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Application.UseCases.Habits.GetOne;

public class GetOneHabitResponse: IUseCaseResponse
{
    public GetOneHabitResponse(Habit habit)
    {
        Habit = habit;
    }

    public Habit Habit { get; }
}