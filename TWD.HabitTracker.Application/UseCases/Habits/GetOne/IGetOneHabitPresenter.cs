using TWD.HabitTracker.Application.Common;

namespace TWD.HabitTracker.Application.UseCases.Habits.GetOne;

public interface IGetOneHabitPresenter : IUseCasePresenter<GetOneHabitResponse>
{
    void NotFound();
}