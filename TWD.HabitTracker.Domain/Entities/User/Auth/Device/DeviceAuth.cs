namespace TWD.HabitTracker.Domain.Entities.User.Auth.Device;

public class DeviceAuth : AuthMean
{
    public DeviceAuth(string deviceToken)
    {
        DeviceToken = deviceToken;
    }
    
    public string DeviceToken { get; }
}