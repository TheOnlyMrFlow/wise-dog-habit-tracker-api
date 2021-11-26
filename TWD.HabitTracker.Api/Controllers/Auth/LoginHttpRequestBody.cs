using System.ComponentModel.DataAnnotations;

namespace TWD.HabitTracker.Api.Controllers.Auth;

public class LoginHttpRequestBody
{
    [Required] public string DeviceToken { get; set; } = null!;
}