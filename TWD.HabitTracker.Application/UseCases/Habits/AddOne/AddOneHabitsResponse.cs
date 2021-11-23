using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Application.UseCases.Habits.AddOne;

public class AddOneHabitResponse: IUseCaseResponse
{
    public AddOneHabitResponse(Habit habit)
    {
        Habit = habit;
    }

    public Habit Habit { get; }
}