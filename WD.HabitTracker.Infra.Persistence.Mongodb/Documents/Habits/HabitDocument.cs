using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Entities.Habits.Stamps;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Habits;

public class HabitDocument
{
    public HabitDocument(MongoDBRef user, string name)
    {
        User = user;
        Name = name;
    }

    public int SchemaVersion { get; set; } = 1;
    
    [BsonId]
    [BsonIgnoreIfDefault]
    public Guid Id { get; set; }
    
    public MongoDBRef User { get; set; }

    public string Name { get; set; }
    public int OccurenceCount { get; set; } = 0;
    public int StampCount { get; set; } = 0;
    public int AboveObjectiveStampCount { get; set; } = 0;
    public DateTime StartDate { get; set; }
    public float? ValueSum { get; set; }
    public float? Objective { get; set; }

    public List<StampDocument> Stamps { get; set; } = new();

    public List<StampDocument> LastTenStamps { get; set; } = new();

    public Habit ToHabit()
    {
        return new Habit(
            Id,
            new Guid(User.Id.ToString()!),
            Name,
            Stamps.Select(s => s.ToStamp()).ToList(),
            LastTenStamps.Select(s => s.ToStamp()).ToList());
    }

    public static HabitDocument FromHabit(Habit habit)
    {
        var stampDocuments = habit.Stamps.Select(StampDocument.FromStamp).ToList();
        var lastTenStampDocuments = habit.LastTenStamps.Select(StampDocument.FromStamp).ToList();
        
        return new(new MongoDBRef("user", new BsonString(habit.UserId.ToString())), habit.Name)
        {
            Stamps = stampDocuments,
            LastTenStamps = lastTenStampDocuments
        };
    }
}

public class StampDocument
{
    public StampDocument(DateTime date, decimal? value)
    {
        Date = date;
        Value = value;
    }
    
    public DateTime Date { get; set; }
    public decimal? Value { get; set; }

    public static StampDocument FromStamp(Stamp stamp)
        => new StampDocument(stamp.Date, stamp.Value);

    public Stamp ToStamp() 
        => new Stamp(Date, Value);
}