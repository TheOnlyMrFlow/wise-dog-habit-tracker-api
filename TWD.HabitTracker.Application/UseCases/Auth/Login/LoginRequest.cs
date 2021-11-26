namespace TWD.HabitTracker.Application.UseCases.Auth.Login;

public class LoginRequest
{
    public LoginRequest(string deviceToken)
    {
        DeviceToken = deviceToken;
    }

    public string DeviceToken { get; }
}