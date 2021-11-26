using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.ViewModels.Habits;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;
using TWD.HabitTracker.Application.UseCases.Habits.GetAll;

namespace TWD.HabitTracker.Api.HttpPresenters.Habits;

public class AddOneHabitHttpPresenter : HttpPresenter<AddOneHabitResponse>, IAddOneHabitPresenter
{
    public override void Success(AddOneHabitResponse response)
    {
        Result = new OkObjectResult(HabitViewModel.FromDomainEntity(response.Habit));
    }
}