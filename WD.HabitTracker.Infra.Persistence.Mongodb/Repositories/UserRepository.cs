using MongoDB.Driver;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Application.Infra.Persistence.Users;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Entities.User;
using WD.HabitTracker.Infra.Persistence.Mongodb.Documents;
using WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Users;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Repositories;

public class UserRepository : IUserReadRepository, IUserWriteRepository
{
    private readonly IMongoCollection<UserDocument> _userCollection;
    
    public UserRepository(HabitTrackerMongoDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _userCollection = database.GetCollection<UserDocument>(settings.UsersCollectionName);
    }

    public async Task AddAsync(User user)
    {
        var doc = new UserDocument(user);
        await _userCollection.InsertOneAsync(doc);
    }

    public async Task<User?> FindByDeviceTokenAsync(string deviceToken)
    {
        var userDocQuery = await _userCollection.FindAsync(d => d.AuthInfo.DeviceAuth != null && d.AuthInfo.DeviceAuth.DeviceToken == deviceToken);
        var userDoc = await userDocQuery.FirstOrDefaultAsync();

        return userDoc?.ToUser();
    }
}