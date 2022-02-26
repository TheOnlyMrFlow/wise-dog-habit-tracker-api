namespace WD.HabitTracker.Persistence.MongoDb.Documents

open System
open MongoDB.Bson.Serialization.Attributes
open MongoDB.Driver

[<CLIMutable>]
[<BsonIgnoreExtraElements>]
type StampDocument = {
//    public StampDocument(DateTime date, float? value)
//    {
//        Date = date;
//        Value = value;
//    }
    
    Date: DateTime
    Value: float option

//    public static StampDocument FromStamp(Stamp stamp)
//        => new StampDocument(stamp.Date, stamp.Value);
//
//    public Stamp ToStamp() 
//        => new Stamp(Date, Value);1
}

[<CLIMutable>]
[<BsonIgnoreExtraElements>]
type HabitDocument = {

//    public HabitDocument(Habit habit)
//    {
//        User = new MongoDBRef("user", new BsonString(habit.UserId.ToString()));
//        Name = habit.Name;
//        StartDate = habit.StartDate;
//        WeekDays = habit.WeekDays.ToArray();
//        ObjectiveValue = habit.Objective?.Value;
//        ObjectiveUnit = habit.Objective?.Unit;
//        Stamps = habit.Stamps.Select(StampDocument.FromStamp).ToList();
//        LastTenStamps = habit.LastTenStamps.Select(StampDocument.FromStamp).ToList();
//    }

    SchemaVersion: int
    [<BsonId>] [<BsonIgnoreIfDefault>] Id: Guid
    User: MongoDBRef
    Name: string    
    StartDate: DateTime    
    WeekDays: DayOfWeek[]
    ObjectiveUnit: string option
    ObjectiveValue: float option
    ValueSum: float option
    AboveObjectiveStampCount: int
    Stamps: List<StampDocument>
    LastTenStamps: List<StampDocument>

//    public Habit ToHabit()
//    {
//        return new Habit(
//            Id,
//            new Guid(User.Id.ToString()!),
//            Name,
//            StartDate,
//            WeekDays,
//            ObjectiveValue.HasValue ? new HabitObjective(ObjectiveValue.Value, ObjectiveUnit) : null,
//            Stamps.Select(s => s.ToStamp()).ToList(),
//            LastTenStamps.Select(s => s.ToStamp()).ToList());
//    }
}

