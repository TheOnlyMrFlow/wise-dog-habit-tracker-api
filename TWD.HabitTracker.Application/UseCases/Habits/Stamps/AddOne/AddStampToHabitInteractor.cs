using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Domain.Exceptions;
using TWD.HabitTracker.Domain.ValueObjects.Stamp;

namespace TWD.HabitTracker.Application.UseCases.Habits.Stamps.AddOne;

public class AddStampToHabitInteractor : UseCaseInteractor<AddStampToHabitRequest, AddStampToHabitResponse, IAddStampToHabitPresenter>
{
    private readonly IHabitReadRepository _habitReadRepository;
    private readonly IHabitWriteRepository _habitWriteRepository;

    public AddStampToHabitInteractor(IHabitReadRepository habitReadRepository, IHabitWriteRepository habitWriteRepository)
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

            var stamp = new Stamp(Request.StampDate, Request.StampValue);
            habit.AddStamp(stamp);

            await _habitWriteRepository.UpdateAsync(habit);
            
            Presenter?.Success(new AddStampToHabitResponse(habit));
        }
        catch (StampMustHaveValueException)
        {
            Presenter?.StampMustHaveValue();
        }
        catch (StampAlreadyExistsException)
        {
            Presenter?.StampAlreadyExists();
        }
    }
}