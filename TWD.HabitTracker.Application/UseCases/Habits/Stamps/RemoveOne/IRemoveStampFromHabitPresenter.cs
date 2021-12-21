using TWD.HabitTracker.Application.Common;

namespace TWD.HabitTracker.Application.UseCases.Habits.Stamps.RemoveOne;

public interface IRemoveStampFromHabitPresenter : IUseCasePresenter<RemoveStampFromHabitResponse>
{
    void NotFound();
}