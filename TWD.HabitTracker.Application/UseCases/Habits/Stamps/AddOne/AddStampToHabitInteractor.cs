﻿using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Domain.Entities.Habits.Stamps;
using TWD.HabitTracker.Domain.Exceptions;

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
            var habit = await _habitReadRepository.Get(Request.HabitId);

            var stamp = new Stamp(Request.StampDate, Request.StampValue);
            try
            {
                habit.AddStamp(stamp);
            }
            catch (StampMustHaveValueException)
            {
                Presenter?.StampMustHaveValue();
                return;
            }

            await _habitWriteRepository.UpdateAsync(habit);
            
            Presenter?.Success(new AddStampToHabitResponse(habit));
        }
        catch (Exception e)
        {
            Presenter?.UnknownError();
        }
    }
}