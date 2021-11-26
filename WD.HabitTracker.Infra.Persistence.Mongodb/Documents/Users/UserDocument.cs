using MongoDB.Bson.Serialization.Attributes;
using TWD.HabitTracker.Domain.Entities.User;
using WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Users.Auth;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Users;

public class UserDocument
{
    public UserDocument(User user)
    {
        Id = user.Id;
        AuthInfo = new AuthInfoDocument(user.AuthInfo);
    }

    public int SchemaVersion { get; set; } = 1;
    
    [BsonId]
    public Guid Id { get; set; }
    
    [BsonElement]
    public AuthInfoDocument AuthInfo { get; set; }

    public User ToUser() => new (Id, AuthInfo.ToAuthInfo());
}