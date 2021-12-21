using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.ViewModels.Habits;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;
using TWD.HabitTracker.Application.UseCases.Habits.Stamps.AddOne;
using TWD.HabitTracker.Application.UseCases.Habits.Stamps.RemoveOne;

namespace TWD.HabitTracker.Api.HttpPresenters.Habits.Stamps;

public class RemoveStampFromHabitHabitHttpPresenter : HttpPresenter<RemoveStampFromHabitResponse>, IRemoveStampFromHabitPresenter
{
    public override void Success(RemoveStampFromHabitResponse response) 
        => Result = new NoContentResult();

    public void NotFound()
        => Result = new NotFoundResult();
}