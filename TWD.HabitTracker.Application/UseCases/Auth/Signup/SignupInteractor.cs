using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Application.Infra.Persistence.Users;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Entities.User;

namespace TWD.HabitTracker.Application.UseCases.Auth.Signup;

public class SignupInteractor : UseCaseInteractor<SignupRequest, SignupResponse, ISignupPresenter>
{
    private readonly IUserWriteRepository _userWriteRepository;

    public SignupInteractor(IUserWriteRepository userWriteRepository)
    {
        _userWriteRepository = userWriteRepository;
    }

    public override async Task InvokeAsync()
    {
        if (Request is null) throw new ArgumentNullException(nameof(Request));

        try
        {
            var secretKey = string.Join(
                    "",
                    Enumerable
                        .Repeat(0, 8)
                        .Select(_ => Convert.ToBase64String(Guid.NewGuid().ToByteArray())))
                .Replace("=", "");

            var user = new User()
            {
                SecretKey = secretKey
            };

            await _userWriteRepository.AddAsync(user);
            Presenter?.PresentSuccess(new SignupResponse(user.SecretKey));
        }
        catch (Exception e)
        {
            Presenter?.PresentUnknownError();

            throw;
        }
    }
}