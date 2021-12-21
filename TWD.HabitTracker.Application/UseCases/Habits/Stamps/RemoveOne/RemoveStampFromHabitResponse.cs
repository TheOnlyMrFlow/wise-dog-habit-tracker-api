using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Application.UseCases.Habits.Stamps.RemoveOne;

public class RemoveStampFromHabitResponse: IUseCaseResponse
{
    public RemoveStampFromHabitResponse(Habit habit)
    {
        Habit = habit;
    }

    public Habit Habit { get; }
}