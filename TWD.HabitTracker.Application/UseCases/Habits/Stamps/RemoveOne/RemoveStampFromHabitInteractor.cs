using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Domain.Exceptions;

namespace TWD.HabitTracker.Application.UseCases.Habits.Stamps.RemoveOne;

public class RemoveStampFromHabitInteractor : UseCaseInteractor<RemoveStampFromHabitRequest, RemoveStampFromHabitResponse, IRemoveStampFromHabitPresenter>
{
    private readonly IHabitReadRepository _habitReadRepository;
    private readonly IHabitWriteRepository _habitWriteRepository;

    public RemoveStampFromHabitInteractor(IHabitReadRepository habitReadRepository, IHabitWriteRepository habitWriteRepository)
    {
        _habitReadRepository = habitReadRepository;
        _habitWriteRepository = habitWriteRepository;
    }

    public override async Task InvokeAsync()
    {
        if (Request is null) throw new ArgumentNullException(nameof(Request));
        
        await (await _habitReadRepository.GetAsync(Request.HabitId))
            .Match(
                async habit =>
                {
                    await habit.RemoveStamp(Request.StampDate).Match(
                        async success =>
                        {
                            Presenter?.Success(new RemoveStampFromHabitResponse(habit));
                            await _habitWriteRepository.UpdateAsync(habit);
                        },
                        error => Task.Run(() => Presenter?.NotFound()));
                }, 
                none => Task.Run(() => Presenter?.NotFound()));
    }
}