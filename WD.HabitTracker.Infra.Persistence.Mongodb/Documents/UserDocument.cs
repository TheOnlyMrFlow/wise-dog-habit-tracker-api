using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using TWD.HabitTracker.Domain.Entities.User;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Documents;

public class UserDocument
{
    public UserDocument()
    {
        
    }

    public int SchemaVersion { get; set; } = 1;
    
    [BsonId]
    public Guid Id { get; set; }
    
    public string SecretKey { get; set; }

    public User ToUser()
    {
        return new User()
        {
            Id = Id,
            SecretKey = SecretKey
        };
    }

    public static UserDocument FromUser(User user)
    {
        return new()
        {
            Id = user.Id,
            SecretKey = user.SecretKey
        };
    }
}