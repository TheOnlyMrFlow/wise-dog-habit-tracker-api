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
            : new QuantifiableObjective(Request.ObjectiveRequest.ObjectiveValue, Request.ObjectiveRequest.ObjectiveUnit);
        
        try
        {
            var habit = new Habit
            {
                UserId = Request.LoggedUser.UserId,
                Name = Request.HabitName,
                QuantifiableObjective = objective
            };

            await _habitWriteRepository.AddAsync(habit);
            Presenter?.Success(new AddOneHabitResponse(habit));
        }
        catch (Exception e)
        {
            Presenter?.UnknownError();

            throw;
        }
    }
}