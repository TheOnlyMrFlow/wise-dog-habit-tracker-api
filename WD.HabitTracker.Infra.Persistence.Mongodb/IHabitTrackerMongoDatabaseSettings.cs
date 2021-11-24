namespace WD.HabitTracker.Infra.Persistence.Mongodb;

public class HabitTrackerMongoDatabaseSettings
{
    public string? HabitsCollectionName { get; set; }
    public string? UsersCollectionName { get; set; }
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}