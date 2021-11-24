namespace TWD.HabitTracker.Domain.Entities.User;

public class User
{
    public Guid Id { get; set; }
    
    public string SecretKey { get; set; }
}