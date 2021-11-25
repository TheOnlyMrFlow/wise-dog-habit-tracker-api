using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Domain.Entities.User;

public class User
{
    public User(Guid id, AuthInfo authInfo)
    {
        Id = id;
        AuthInfo = authInfo;
    }
    
    public User(AuthInfo authInfo)
    {
        Id = Guid.NewGuid();
        AuthInfo = authInfo;
    }
    
    public Guid Id { get; set; }

    public AuthInfo AuthInfo { get; set; }
}