using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Application.UseCases.Auth.Login;

namespace TWD.HabitTracker.Api.HttpPresenters.Auth;

public class LoginHttpPresenter : HttpPresenter<LoginResponse>, ILoginPresenter
{
    public override void Success(LoginResponse response)
    {
        Result = new OkObjectResult(new {Token = response.JwtToken});
    }

    public void Forbid()
    {
        Result = new ForbidResult();
    }
}