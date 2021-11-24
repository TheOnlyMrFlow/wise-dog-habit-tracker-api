using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.HttpPresenters.Auth;
using TWD.HabitTracker.Application.UseCases.Auth.Signup;

namespace TWD.HabitTracker.Api.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpPost("signup", Name = "Signup")]
    public async Task<IActionResult?> Signup([FromServices] SignupInteractor interactor)
    {
        var presenter = new SignupHttpPresenter();
        
        await interactor
            .SetRequest(new SignupRequest() {})
            .SetPresenter(presenter)
            .InvokeAsync();

        return presenter.Result;
    }
}