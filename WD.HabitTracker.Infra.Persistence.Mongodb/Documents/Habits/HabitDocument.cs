using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Habits;

public class HabitDocument
{
    public HabitDocument(MongoDBRef user)
    {
        User = user;
    }

    public int SchemaVersion { get; set; } = 1;
    
    [BsonId]
    public Guid Id { get; set; }
    
    public MongoDBRef User { get; set; }

    public string Name { get; set; }
    public int OccurenceCount { get; set; } = 0;
    public int StampCount { get; set; } = 0;
    public int AboveObjectiveStampCount { get; set; } = 0;
    public DateTime StartDate { get; set; }
    public float? ValueSum { get; set; }
    public float? Objective { get; set; }

    public List<MongoDBRef> Stamps { get; set; } = new();

    public List<LightStamp> LastTenStamps { get; set; } = new();

    public Habit ToHabit()
    {
        return new Habit
        {
            Id = Id,
            Name = Name,
            Stamps = {  },
            UserId = new Guid(User.ToString())
        };
    }

    public static HabitDocument FromHabit(Habit habit)
    {
        return new(new MongoDBRef("user", new BsonString(habit.UserId.ToString())))
        {
            Name = habit.Name
        };
    }
}

public class LightStamp
{
    public DateTime Date { get; set; }
    public float? Value { get; set; }
}