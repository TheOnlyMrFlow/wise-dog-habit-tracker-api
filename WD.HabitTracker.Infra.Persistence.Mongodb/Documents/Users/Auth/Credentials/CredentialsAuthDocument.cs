using TWD.HabitTracker.Domain.Entities.User.Auth.Credentials;
using TWD.HabitTracker.Domain.ValueObjects.Password;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Users.Auth.Credentials;

public class CredentialsAuthDocument
{
    public CredentialsAuthDocument(CredentialsAuth credentialsAuth)
    {
        Email = credentialsAuth.Email;
        Password = credentialsAuth.Password;
    }
    
    public string Email { get; }
    public string Password { get; }

    public CredentialsAuth ToCredentialsAuth() => new(Email,Password);
}