using MongoDB.Driver;
using TWD.HabitTracker.Application.Infra.Persistence.Habits;
using TWD.HabitTracker.Domain.Entities.Habits;
using WD.HabitTracker.Infra.Persistence.Mongodb.Documents;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Repositories;

public class HabitRepository: IHabitReadRepository, IHabitWriteRepository
{
    private readonly IMongoCollection<HabitDocument> _habitCollection;
    
    public HabitRepository(HabitTrackerMongoDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _habitCollection = database.GetCollection<HabitDocument>(settings.HabitsCollectionName);
    }

    public IEnumerable<Habit> GetAll(Guid userId)
    {
        return _habitCollection.FindSync(document => true).ToEnumerable().Select(doc => doc.ToHabit());
    }

    public async Task AddAsync(Habit habit)
    {
        await _habitCollection.InsertOneAsync(HabitDocument.FromHabit(habit));
    }
}