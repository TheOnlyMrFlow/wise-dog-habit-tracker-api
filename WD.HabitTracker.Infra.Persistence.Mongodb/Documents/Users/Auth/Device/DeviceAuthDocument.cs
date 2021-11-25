using TWD.HabitTracker.Domain.Entities.User.Auth.Device;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Users.Auth.Device;

public class DeviceAuthDocument
{
    public DeviceAuthDocument(DeviceAuth deviceAuth)
    {
        DeviceToken = deviceAuth.DeviceToken;
    }
    
    public string DeviceToken { get; set; }

    public DeviceAuth ToDeviceAuth() => new (DeviceToken);
}