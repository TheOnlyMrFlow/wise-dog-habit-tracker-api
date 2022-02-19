using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Entities.Habits.Stamps;
using TWD.HabitTracker.Domain.ValueObjects;

namespace WD.HabitTracker.Infra.Persistence.Mongodb.Documents.Habits;

[BsonIgnoreExtraElements]
public class HabitDocument
{
    public HabitDocument(Habit habit)
    {
        User = new MongoDBRef("user", new BsonString(habit.UserId.ToString()));
        Name = habit.Name;
        StartDate = habit.StartDate;
        WeekDays = habit.WeekDays.ToArray();
        ObjectiveValue = habit.Objective?.Value;
        ObjectiveUnit = habit.Objective?.Unit;
        Stamps = habit.Stamps.Select(StampDocument.FromStamp).ToList();
        LastTenStamps = habit.LastTenStamps.Select(StampDocument.FromStamp).ToList();
    }

    public int SchemaVersion { get; set; } = 1;
    
    [BsonId]
    [BsonIgnoreIfDefault]
    public Guid Id { get; set; }
    
    public MongoDBRef User { get; set; }

    public string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DayOfWeek[] WeekDays { get; set; }
    
    public string? ObjectiveUnit { get; set; }
    public float? ObjectiveValue { get; set; }
    
    public float? ValueSum { get; set; }
    public int AboveObjectiveStampCount { get; set; } = 0;

    public List<StampDocument> Stamps { get; set; } = new();

    public List<StampDocument> LastTenStamps { get; set; } = new();

    public Habit ToHabit()
    {
        return new Habit(
            Id,
            new Guid(User.Id.ToString()!),
            Name,
            StartDate,
            WeekDays,
            ObjectiveValue.HasValue ? new HabitObjective(ObjectiveValue.Value, ObjectiveUnit) : null,
            Stamps.Select(s => s.ToStamp()).ToList(),
            LastTenStamps.Select(s => s.ToStamp()).ToList());
    }
}

public class StampDocument
{
    public StampDocument(DateTime date, float? value)
    {
        Date = date;
        Value = value;
    }
    
    public DateTime Date { get; set; }
    public float? Value { get; set; }

    public static StampDocument FromStamp(Stamp stamp)
        => new StampDocument(stamp.Date, stamp.Value);

    public Stamp ToStamp() 
        => new Stamp(Date, Value);
}