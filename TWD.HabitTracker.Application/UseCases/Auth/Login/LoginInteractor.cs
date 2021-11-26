using TWD.HabitTracker.Application.Common;
using TWD.HabitTracker.Application.Infra.Persistence.Users;
using TWD.HabitTracker.Domain.Entities.User;
using TWD.HabitTracker.Domain.Entities.User.Auth;
using TWD.HabitTracker.Domain.Entities.User.Auth.Device;

namespace TWD.HabitTracker.Application.UseCases.Auth.Login;

public class LoginInteractor : UseCaseInteractor<LoginRequest, LoginResponse, ILoginPresenter>
{
    private readonly IUserReadRepository _userReadRepository;

    public LoginInteractor(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public override async Task InvokeAsync()
    {
        if (Request is null) throw new ArgumentNullException(nameof(Request));

        try
        {
            var user = await _userReadRepository.FindByDeviceTokenAsync(Request.DeviceToken);
            
            // todo generate jwt and return it
        }
        catch (Exception e)
        {
            Presenter?.PresentUnknownError();

            throw;
        }
    }
}