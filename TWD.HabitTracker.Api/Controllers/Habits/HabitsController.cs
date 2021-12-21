using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.HttpPresenters.Habits;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;
using TWD.HabitTracker.Application.UseCases.Habits.GetAll;
using TWD.HabitTracker.Application.UseCases.Habits.GetOne;

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
    public async Task<IActionResult?> GetHabitsAsync([FromServices] GetAllHabitsInteractor interactor)
    {
        var presenter = new GetAllHabitsHttpPresenter();
        
        await interactor
            .SetRequest(new GetAllHabitsRequest(this.GetLoggedUser()))
            .SetPresenter(presenter)
            .InvokeAsync();

        return presenter.Result;
    }
    
    [Authorize]
    [HttpGet("{habitId:guid}", Name = "Get one habit")]
    public async Task<IActionResult?> GetOneHabitAsync([FromServices] GetOneHabitInteractor interactor, [FromRoute] Guid habitId)
    {
        var presenter = new GetOneHabitHttpPresenter();
        
        await interactor
            .SetRequest(new GetOneHabitRequest(this.GetLoggedUser(), habitId))
            .SetPresenter(presenter)
            .InvokeAsync();

        return presenter.Result;
    }
    
    [Authorize]
    [HttpPost(Name = "Post habit")]
    public async Task<IActionResult?> PostHabitAsync([FromServices] AddOneHabitInteractor interactor, [FromBody] CreateHabitHttpBody httpBody)
    {
        var presenter = new AddOneHabitHttpPresenter();
        
        await interactor
            .SetRequest(httpBody.ToApplicationRequest(this.GetLoggedUser()))
            .SetPresenter(presenter)
            .InvokeAsync();

        return presenter.Result;
    }
}