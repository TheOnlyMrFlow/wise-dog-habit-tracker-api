namespace WD.HabitTracker.Persistence.MongoDb

open MongoDB.Driver
open WD.HabitTracker.Persistence.MongoDb.Documents

type HabitTrackerMongoDatabase(settings: HabitTrackerMongoDatabaseSettings) =
    let database = MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName)
    
    member this.GetHabitCollection = fun () -> database.GetCollection<HabitDocument>(settings.HabitsCollectionName)
    member this.GetUserCollection = fun () -> database.GetCollection<UserDocument>(settings.UsersCollectionName)