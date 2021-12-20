using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Application.UseCases.Habits.Stamps.AddOne;

public class AddStampToHabitResponse: IUseCaseResponse
{
    public AddStampToHabitResponse(Habit habit)
    {
        Habit = habit;
    }

    public Habit Habit { get; }
}