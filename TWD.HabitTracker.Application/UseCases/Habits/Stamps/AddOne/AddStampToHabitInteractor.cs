using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Domain.Common;
using TWD.HabitTracker.Domain.Exceptions;
using TWD.HabitTracker.Domain.ValueObjects.Stamp;

namespace TWD.HabitTracker.Application.UseCases.Habits.Stamps.AddOne;

public class AddStampToHabitInteractor : UseCaseInteractor<AddStampToHabitRequest, AddStampToHabitResponse, IAddStampToHabitPresenter>
{
    private readonly IHabitReadRepository _habitReadRepository;
    private readonly IHabitWriteRepository _habitWriteRepository;

    public AddStampToHabitInteractor(IHabitReadRepository habitReadRepository,
        IHabitWriteRepository habitWriteRepository)
    {
        _habitReadRepository = habitReadRepository;
        _habitWriteRepository = habitWriteRepository;
    }

    public override async Task InvokeAsync()
    {
        if (Request is null) throw new ArgumentNullException(nameof(Request));

        var maybeHabit = await _habitReadRepository.GetAsync(Request.HabitId);
            
        await maybeHabit.Match(
            async habit =>
            {
                var stamp = new Stamp(Request.StampDate, Request.StampValue);

                await habit.AddStamp(stamp).Match(
                    async _ =>
                    {
                        await _habitWriteRepository.UpdateAsync(habit);
                        Presenter?.Success(new AddStampToHabitResponse(habit));
                    },
                    error =>
                    {
                        Presenter?.StampMustHaveValue();
                        return Task.CompletedTask;
                    },
                    error =>
                    {
                        Presenter?.StampAlreadyExists();
                        return Task.CompletedTask;
                    });
            },
            none => Task.Run(() => Presenter?.NotFound())
        );
    }
}