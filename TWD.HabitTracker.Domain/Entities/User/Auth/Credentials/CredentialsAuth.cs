using TWD.HabitTracker.Domain.ValueObjects.Password;

namespace TWD.HabitTracker.Domain.Entities.User.Auth.Credentials;

public class CredentialsAuth
{
    public CredentialsAuth(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
    public string Email { get; set; }
    public string Password { get; set; }
}