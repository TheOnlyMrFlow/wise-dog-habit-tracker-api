using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Application.UseCases.Habits.AddOne;

public class AddOneHabitInteractor : UseCaseInteractor<AddOneHabitRequest, AddOneHabitResponse, IAddOneHabitPresenter>
{
    private readonly IHabitWriteRepository _habitWriteRepository;

    public AddOneHabitInteractor(IHabitWriteRepository habitWriteRepository)
    {
        _habitWriteRepository = habitWriteRepository;
    }

    public override async Task InvokeAsync()
    {
        if (Request is null) throw new ArgumentNullException(nameof(Request));

        try
        {
            var habit = new Habit
            {
                UserId = Request.UserId
            };

            await _habitWriteRepository.AddAsync(habit);
            Presenter?.PresentSuccess(new AddOneHabitResponse(habit));
        }
        catch (Exception e)
        {
            Presenter?.PresentUnknownError();

            throw;
        }
    }
}