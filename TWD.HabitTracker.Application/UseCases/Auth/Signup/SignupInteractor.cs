using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Application.Infra.Persistence.Users;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Entities.User;
using TWD.HabitTracker.Domain.Entities.User.Auth;
using TWD.HabitTracker.Domain.Entities.User.Auth.Device;

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
        
        var deviceToken = string.Join(
                "",
                Enumerable
                    .Repeat(0, 8)
                    .Select(_ => Convert.ToBase64String(Guid.NewGuid().ToByteArray())))
            .Replace("=", "");

        var authInfo = new AuthInfo();

        authInfo.DeviceAuth = new DeviceAuth(deviceToken);

        var user = new User(authInfo);

        await _userWriteRepository.AddAsync(user);
        Presenter?.Success(new SignupResponse(deviceToken));
    
    }
}