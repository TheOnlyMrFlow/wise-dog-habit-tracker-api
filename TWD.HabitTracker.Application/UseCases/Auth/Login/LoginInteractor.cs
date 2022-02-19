using TWD.HabitTracker.Application.Authentication;
using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Users;

namespace TWD.HabitTracker.Application.UseCases.Auth.Login;

public class LoginInteractor : UseCaseInteractor<LoginRequest, LoginResponse, ILoginPresenter>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IJwtManager _jwtManager;

    public LoginInteractor(IUserReadRepository userReadRepository, IJwtManager jwtManager)
    {
        _userReadRepository = userReadRepository;
        _jwtManager = jwtManager;
    }

    public override async Task InvokeAsync()
    {
        if (Request is null) throw new ArgumentNullException(nameof(Request));
        
        var user = await _userReadRepository.FindByDeviceTokenAsync(Request.DeviceToken);

        if (user is null)
        {
            Presenter?.Forbid();
            return;
        }

        var jwt = _jwtManager.BuildForDeviceAuth(user);
        
        Presenter?.Success(new LoginResponse(jwt));
    }
}