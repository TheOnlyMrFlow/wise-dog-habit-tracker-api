using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.ViewModels.Habits;
using TWD.HabitTracker.Application.UseCases.Auth.Signup;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;

namespace TWD.HabitTracker.Api.HttpPresenters.Auth;

public class SignupHttpPresenter : HttpPresenter<SignupResponse>, ISignupPresenter
{
    public override void PresentSuccess(SignupResponse response)
    {
        Result = new OkObjectResult(new {DeviceToken = response.DeviceToken});
    }
}