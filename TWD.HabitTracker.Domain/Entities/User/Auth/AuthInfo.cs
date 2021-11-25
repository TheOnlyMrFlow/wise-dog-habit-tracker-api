using TWD.HabitTracker.Domain.Entities.User.Auth.Credentials;
using TWD.HabitTracker.Domain.Entities.User.Auth.Device;

namespace TWD.HabitTracker.Domain.Entities.User.Auth;

public class AuthInfo
{
    public DeviceAuth? DeviceAuth { get; set; }
    
    public CredentialsAuth? CredentialsAuth { get; set; }
}