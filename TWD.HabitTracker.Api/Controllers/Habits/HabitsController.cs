using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.HttpPresenters.Habits;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;
using TWD.HabitTracker.Application.UseCases.Habits.GetAll;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Api.Controllers.Habits;

[ApiController]
[Route("[controller]")]
public class HabitsController : ControllerBase
{
    private readonly ILogger<HabitsController> _logger;

    public HabitsController(ILogger<HabitsController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    [HttpGet(Name = "Get habits")]
    public async Task<IActionResult?> GetHabits([FromServices] GetAllHabitsInteractor interactor)
    {
        var presenter = new GetAllHabitsHttpPresenter();
        
        await interactor
            .SetRequest(new GetAllHabitsRequest(new LoggedUser(User.Claims)))
            .SetPresenter(presenter)
            .InvokeAsync();

        return presenter.Result;
    }
    
    [HttpPost(Name = "Post habit")]
    public async Task<IActionResult?> PostHabit([FromServices] AddOneHabitInteractor interactor)
    {
        var presenter = new AddOneHabitHttpPresenter();
        
        await interactor
            .SetRequest(new AddOneHabitRequest {UserId = Guid.NewGuid()})
            .SetPresenter(presenter)
            .InvokeAsync();

        return presenter.Result;
    }
}