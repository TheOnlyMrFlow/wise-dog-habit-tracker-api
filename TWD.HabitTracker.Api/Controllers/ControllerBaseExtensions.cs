using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Api.Controllers;

public static class ControllerBaseExtensions
{
    public static LoggedUser GetLoggedUser(this ControllerBase controller) => new(controller.User);
}