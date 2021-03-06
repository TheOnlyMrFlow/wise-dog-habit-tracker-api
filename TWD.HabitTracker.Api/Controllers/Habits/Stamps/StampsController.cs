using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Api.HttpPresenters.Habits.Stamps;
using TWD.HabitTracker.Application.UseCases.Habits.Stamps.AddOne;
using TWD.HabitTracker.Application.UseCases.Habits.Stamps.RemoveOne;

namespace TWD.HabitTracker.Api.Controllers.Habits.Stamps;

[ApiController]
[Route("habits/{habitId:guid}/[controller]")]
public class StampsController : ControllerBase
{
    private readonly ILogger<StampsController> _logger;

    public StampsController(ILogger<StampsController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    [HttpPost(Name = "Post stamp")]
    public async Task<IActionResult?> PostStampAsync([FromServices] AddStampToHabitInteractor interactor, [FromRoute] Guid habitId, [FromBody] AddStampToHabitHttpHttpBody httpBody)
    {
        var presenter = new AddStampToHabitHabitHttpPresenter();
        
        await interactor
            .SetRequest(httpBody.ToApplicationRequest(this.GetLoggedUser(), habitId))
            .SetPresenter(presenter)
            .InvokeAsync();

        return presenter.Result;
    }
    
    [Authorize]
    [HttpDelete(Name = "Delete stamp")]
    public async Task<IActionResult?> DeleteStampAsync([FromServices] RemoveStampFromHabitInteractor interactor, [FromRoute] Guid habitId, [FromBody] RemoveStampFromHabitHttpHttpBody httpBody)
    {
        var presenter = new RemoveStampFromHabitHabitHttpPresenter();
        
        await interactor
            .SetRequest(httpBody.ToApplicationRequest(this.GetLoggedUser(), habitId))
            .SetPresenter(presenter)
            .InvokeAsync();

        return presenter.Result;
    }
}