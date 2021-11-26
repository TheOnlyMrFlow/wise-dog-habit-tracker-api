using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.HttpPresenters.Auth;
using TWD.HabitTracker.Application.UseCases.Auth.Login;
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
    
    [HttpPost("login", Name = "Login")]
    public async Task<IActionResult?> Login([FromServices] LoginInteractor interactor, [FromBody] LoginHttpRequestBody body)
    {
        var presenter = new LoginHttpPresenter();
        
        await interactor
            .SetRequest(new LoginRequest(body.DeviceToken))
            .SetPresenter(presenter)
            .InvokeAsync();

        return presenter.Result;
    }
}