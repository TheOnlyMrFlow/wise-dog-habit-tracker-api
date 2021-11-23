using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;

namespace TWD.HabitTracker.Application.UseCases.Habits.GetAll;

public class GetAllHabitsInteractor : UseCaseInteractor<GetAllHabitsRequest, GetAllHabitsResponse, IGetAllHabitsPresenter>
{
    private readonly IHabitReadRepository _habitReadRepository;

    public GetAllHabitsInteractor(IHabitReadRepository habitReadRepository)
    {
        _habitReadRepository = habitReadRepository;
    }

    public override Task InvokeAsync()
    {
        if (Request is null) throw new ArgumentNullException(nameof(Request));

        try
        {
            var habits = _habitReadRepository.GetAll(Request.UserId);
            Presenter?.PresentSuccess(new GetAllHabitsResponse(habits));
        }
        catch (Exception e)
        {
            Presenter?.PresentUnknownError();
        }

        return Task.CompletedTask;
    }
}