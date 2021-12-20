using System.ComponentModel.DataAnnotations;

namespace TWD.HabitTracker.Api.Controllers.Auth;

public class LoginHttpBody
{
    [Required] public string DeviceToken { get; set; } = null!;
}