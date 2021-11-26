using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.ViewModels.Habits;
using TWD.HabitTracker.Application.UseCases.Habits.GetAll;

namespace TWD.HabitTracker.Api.HttpPresenters.Habits;

public class GetAllHabitsHttpPresenter : HttpPresenter<GetAllHabitsResponse>, IGetAllHabitsPresenter
{
    public override void Success(GetAllHabitsResponse response)
    {
        Result = new OkObjectResult(response.Habits.Select(HabitViewModel.FromDomainEntity));
    }
}