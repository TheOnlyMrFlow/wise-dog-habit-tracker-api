using TWD.HabitTracker.Application.Common;

namespace TWD.HabitTracker.Application.UseCases.Habits.Stamps.AddOne;

public interface IAddStampToHabitPresenter : IUseCasePresenter<AddStampToHabitResponse>
{
    void StampMustHaveValue();
}