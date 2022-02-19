using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;

namespace TWD.HabitTracker.Application.UseCases.Habits.GetOne;

public class GetOneHabitInteractor : UseCaseInteractor<GetOneHabitRequest, GetOneHabitResponse, IGetOneHabitPresenter>
{
    private readonly IHabitReadRepository _habitReadRepository;

    public GetOneHabitInteractor(IHabitReadRepository habitReadRepository)
    {
        _habitReadRepository = habitReadRepository;
    }

    public override async Task InvokeAsync()
    {
        if (Request is null) throw new ArgumentNullException(nameof(Request));
        var habit = await _habitReadRepository.GetAsync(Request.HabitId);
        if (habit is null || habit.UserId != Request.LoggedUser.UserId)
        {
            Presenter?.NotFound();
            return;
        }
        
        Presenter?.Success(new GetOneHabitResponse(habit));
    }
}