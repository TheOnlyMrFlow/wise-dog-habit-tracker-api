using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Application.UseCases.Auth.Signup;

public class SignupResponse: IUseCaseResponse
{
    public SignupResponse(string secretKey)
    {
        SecretKey = secretKey;
    }

    public string SecretKey { get; }
}