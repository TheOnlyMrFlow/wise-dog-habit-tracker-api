using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.ValueObjects;

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

        var objective = Request.ObjectiveRequest is null
            ? null
            : new HabitObjective(Request.ObjectiveRequest.ObjectiveValue, Request.ObjectiveRequest.ObjectiveUnit);
    
        var habit = new Habit(Request.LoggedUser.UserId, Request.HabitName, Request.StartDate, Request.WeekDays, objective);

        await _habitWriteRepository.AddAsync(habit);
        Presenter?.Success(new AddOneHabitResponse(habit));
    }
}