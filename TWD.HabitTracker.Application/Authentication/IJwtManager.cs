using TWD.HabitTracker.Domain.Entities.User;

namespace TWD.HabitTracker.Application.Authentication;

public interface IJwtManager
{
    public string BuildForDeviceAuth(User user);

    public string BuildForCredentialsAuth(User user);
}