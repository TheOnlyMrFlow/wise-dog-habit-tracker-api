namespace WD.HabitTracker.Persistence.MongoDb

type HabitTrackerMongoDatabaseSettings = {
    HabitsCollectionName: string
    UsersCollectionName: string
    ConnectionString: string
    DatabaseName: string
}