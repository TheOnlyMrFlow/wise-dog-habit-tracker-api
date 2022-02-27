namespace WD.HabitTracker.Persistence.MongoDb

type HabitTrackerMongoDatabaseSettings () =
    member val HabitsCollectionName: string = "" with get,set
    member val UsersCollectionName: string = "" with get,set
    member val ConnectionString: string = "" with get,set
    member val DatabaseName: string = "" with get,set