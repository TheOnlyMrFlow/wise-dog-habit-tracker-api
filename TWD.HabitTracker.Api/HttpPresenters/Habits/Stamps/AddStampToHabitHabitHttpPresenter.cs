using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.ViewModels.Habits;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;
using TWD.HabitTracker.Application.UseCases.Habits.Stamps.AddOne;

namespace TWD.HabitTracker.Api.HttpPresenters.Habits.Stamps;

public class AddStampToHabitHabitHttpPresenter : HttpPresenter<AddStampToHabitResponse>, IAddStampToHabitPresenter
{
    public override void Success(AddStampToHabitResponse response) 
        => Result = new OkObjectResult(new HabitLightViewModel(response.Habit));

    public void StampMustHaveValue() 
        => Result = new BadRequestObjectResult(new ValidationProblemDetails { Title = "Stamp must have a value." });

    public void NotFound()
        => Result = new NotFoundResult();

    public void StampAlreadyExists()
        => Result = new ConflictResult();
}