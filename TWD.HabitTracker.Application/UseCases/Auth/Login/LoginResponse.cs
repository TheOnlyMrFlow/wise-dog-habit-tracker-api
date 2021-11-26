using TWD.HabitTracker.Application.Common;

namespace TWD.HabitTracker.Application.UseCases.Auth.Login;

public class LoginResponse: IUseCaseResponse
{
    public LoginResponse(object jwtToken)
    {
        JwtToken = jwtToken;
    }

    public object JwtToken { get; }
}