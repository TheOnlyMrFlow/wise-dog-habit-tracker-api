using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.ViewModels.Habits;
using TWD.HabitTracker.Application.UseCases.Habits.GetOne;

namespace TWD.HabitTracker.Api.HttpPresenters.Habits;

public class GetOneHabitHttpPresenter : HttpPresenter<GetOneHabitResponse>, IGetOneHabitPresenter
{
    public override void Success(GetOneHabitResponse response) 
        => Result = new OkObjectResult(new HabitFullViewModel(response.Habit));

    public void NotFound() 
        => Result = new NotFoundResult();
}