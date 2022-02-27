namespace WD.HabitTracker.Persistence.MongoDb

open System.Threading.Tasks
open Microsoft.FSharp.Control
open MongoDB.Driver
open WD.HabitTracker.Application.Services.Persistence
open WD.HabitTracker.Application.Services.Persistence.PersistenceServices.CommonErrors
open WD.HabitTracker.Domain.Users
open WD.HabitTracker.Persistence.MongoDb.Documents

type UserRepository(client: HabitTrackerMongoDatabase) =
    let habitCollection = client.GetHabitCollection ()
    
    interface IUserReadRepository with
        member this.FindUserByDeviceTokenAsync(deviceToken) = async {
            try 
                do! Async.Sleep(100)
//                let habitRes = FilterDefinition<HabitDocument>.Empty |> habitCollection.Find
//                let habit = habitRes.Skip(1).First ()
                let! h = habitCollection.FindAsync<HabitDocument>(FilterDefinition<HabitDocument>.Empty) |> Async.AwaitTask
                let hh = h.First()
                return {
                    Id = hh.Id
                    AuthenticationMean = Device {DeviceToken = $"lol{hh.Name}" }
                } |> Some |> Ok
            with
            | _ -> return "Something terrible happened" |> PersistenceError |> Error
        }