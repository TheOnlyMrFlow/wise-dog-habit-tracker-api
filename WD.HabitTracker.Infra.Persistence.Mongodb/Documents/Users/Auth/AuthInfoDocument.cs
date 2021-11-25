using TWD.HabitTracker.Domain.Entities.User.Auth;
using WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Users.Auth.Credentials;
using WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Users.Auth.Device;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Users.Auth;

public class AuthInfoDocument
{
    public AuthInfoDocument(AuthInfo authInfo)
    {
        DeviceAuth = authInfo.DeviceAuth is null ? null : new DeviceAuthDocument(authInfo.DeviceAuth);
        CredentialsAuth = authInfo.CredentialsAuth is null ? null : new CredentialsAuthDocument(authInfo.CredentialsAuth);
    }
    
    public DeviceAuthDocument? DeviceAuth { get; }
    public CredentialsAuthDocument? CredentialsAuth { get; }

    public AuthInfo ToAuthInfo()
        => new ()
        {
            DeviceAuth = DeviceAuth?.ToDeviceAuth(),
            CredentialsAuth = CredentialsAuth?.ToCredentialsAuth(),
        };
}