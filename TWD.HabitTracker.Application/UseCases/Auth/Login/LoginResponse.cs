using TWD.HabitTracker.Application.Common;

namespace TWD.HabitTracker.Application.UseCases.Auth.Login;

public class LoginResponse: IUseCaseResponse
{
    public LoginResponse(string jwtToken)
    {
        JwtToken = jwtToken;
    }

    public string JwtToken { get; }
}