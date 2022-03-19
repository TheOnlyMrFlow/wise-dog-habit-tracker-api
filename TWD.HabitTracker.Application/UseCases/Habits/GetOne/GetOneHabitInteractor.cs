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
        
        (await _habitReadRepository.GetAsync(Request.HabitId))
            .Switch(
                habit =>
                {
                    if (habit.UserId == Request.LoggedUser.UserId)
                        Presenter?.Success(new GetOneHabitResponse(habit));
                    else
                        Presenter?.NotFound();
                }, 
                none => Presenter?.NotFound());
    }
}