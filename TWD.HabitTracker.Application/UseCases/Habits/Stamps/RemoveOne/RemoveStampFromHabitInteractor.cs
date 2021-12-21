using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Domain.Entities.Habits.Stamps;
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

        try
        {
            var habit = await _habitReadRepository.GetAsync(Request.HabitId);
            if (habit is null)
            {
                Presenter?.NotFound();
                return;
            }
            
            habit.RemoveStamp(Request.StampDate);

            await _habitWriteRepository.UpdateAsync(habit);
            
            Presenter?.Success(new RemoveStampFromHabitResponse(habit));
        }
        catch (StampNotFoundException)
        {
            Presenter?.NotFound();
        }
        catch (Exception e)
        {
            Presenter?.UnknownError();
        }
    }
}